using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

namespace ShareX.UploadersLib.ImageUploaders
{
    public class DirectusImageUploaderService : ImageUploaderService
    {
        public override ImageDestination EnumValue { get; } = ImageDestination.Directus;

        public override bool CheckConfig(UploadersConfig config) => true;

        public override GenericUploader CreateUploader(UploadersConfig config, TaskReferenceHelper taskInfo)
        {
            return new DirectusUploader
            {
                AccessToken = config.DirectusAccessToken,
                PatientId = config.DirectusSessionPatientId,
                CaseId = config.DirectusSessionCaseId,
                CapturedBy = config.DirectusSessionUser,
                Metadata = config.DirectusSessionMetadata
            };
        }
    }

    public class DirectusUploader : ImageUploader
    {
        private static readonly string DirectusBaseUrl = ConfigurationManager.AppSettings["DirectusBaseUrl"];
        private static readonly string ScreenshotUploadEndpoint = "/custom/upload-dicom-screenshot";
        private static readonly string CaseEndpoint = "/items/case";
        private static readonly string UploadUrl = DirectusBaseUrl + ScreenshotUploadEndpoint;

        public string PatientId { get; set; }
        public string CaseId { get; set; }
        public string Metadata { get; set; }
        public string AccessToken { get; set; }
        public string CapturedBy { get; set; }

        public Action ResetSessionAction { get; set; }

        private bool PreUploadCheck()
        {
            if (string.IsNullOrEmpty(AccessToken))
            {
                Errors.Add("Access Token is required for Directus authentication.");
                return false;
            }

            if (string.IsNullOrEmpty(CaseId))
            {
                Errors.Add("Case ID is required for Directus upload.");
                return false;
            }

            string requestUrl = $"{DirectusBaseUrl}{CaseEndpoint}/{CaseId}?fields=status,patients.id";
            string json = null;
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
                request.Method = "GET";
                request.Headers.Add("Authorization", $"Bearer {AccessToken}");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    statusCode = response.StatusCode;
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Response is HttpWebResponse errorResponse)
                {
                    statusCode = errorResponse.StatusCode;
                    using (Stream stream = errorResponse.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }

                    string debugMsg = $"HTTP ERROR Status: {statusCode}. Response: {json}";

                    if (statusCode == HttpStatusCode.NotFound || statusCode == HttpStatusCode.Forbidden)
                    {
                        Errors.Add($"Sorry, this file cannot be uploaded. Related patient is unavailable. HTTP Status: {statusCode}");
                        return false;
                    }
                    else
                    {
                        Errors.Add($"Pre-check failed due to unexpected HTTP error: {statusCode}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Errors.Add($"Pre-check failed due to critical exception: {ex.Message}");
                return true;
            }

            if (string.IsNullOrEmpty(json))
            {
                Errors.Add("Pre-check failed: received empty response body.");
                return true;
            }

            try
            {
                var directusResponse = JsonConvert.DeserializeObject<DirectusSingleItemResponseWrapper>(json);
                DirectusCaseData caseData = directusResponse?.Data;

                if (caseData == null)
                {
                    Errors.Add("Pre-check failed: Case data is null in response.");
                    return true;
                }

                if (caseData.Status == "Closed")
                {
                    Errors.Add("Sorry, this file cannot be uploaded. Related case is closed.");
                    return false;
                }

                bool isPatientPresent = caseData.Patients?
                    .Any(p => p.Id == this.PatientId)
                    ?? false;

                if (!isPatientPresent)
                {
                    Errors.Add("Sorry, this file cannot be uploaded. Related patient is unavailable.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Errors.Add($"Pre-check failed due to JSON parsing error: {ex.Message}");
                return true;
            }

            return true;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            if (!PreUploadCheck())
            {
                return new UploadResult
                {
                    IsSuccess = false,
                };
            }

            if (string.IsNullOrEmpty(PatientId))
            {
                Errors.Add("PatientId is required for Directus DICOM screenshot upload.");
                return null;
            }
            if (string.IsNullOrEmpty(AccessToken))
            {
                Errors.Add("Access Token is required for Directus authentication.");
                return null;
            }

            NameValueCollection headers = new NameValueCollection();
            headers.Add("Authorization", $"Bearer {AccessToken}");

            NameValueCollection argsCollection = new NameValueCollection();
            argsCollection.Add("patient_id", this.PatientId);
            argsCollection.Add("user_id", this.CapturedBy);
            argsCollection.Add("metadata", this.Metadata ?? "screenshot");

            Dictionary<string, string> argsDictionary = new Dictionary<string, string>();
            foreach (string key in argsCollection.AllKeys)
            {
                if (argsCollection[key] != null)
                {
                    if (!argsDictionary.ContainsKey(key))
                    {
                        argsDictionary.Add(key, argsCollection[key]);
                    }
                }
            }

            const string fileFormName = "file";

            UploadResult result = base.SendRequestFile(
                UploadUrl,
                stream,
                fileName,
                fileFormName,
                argsDictionary,
                headers
            );

            if (!result.IsSuccess)
            {
                if (result.StatusCode == HttpStatusCode.Unauthorized || result.StatusCode == HttpStatusCode.Forbidden)
                {
                    UploadResult cleanResult = new UploadResult
                    {
                        IsSuccess = false,
                        StatusCode = result.StatusCode,
                        Response = result.Response,
                        ResetSessionAction = this.ResetSessionAction
                    };

                    cleanResult.ResetSessionAction?.Invoke();

                    return cleanResult;
                }
            }

            if (!string.IsNullOrEmpty(result.Response))
            {
                DirectusDicomUploadResponse uploadResponse = JsonConvert.DeserializeObject<DirectusDicomUploadResponse>(result.Response);

                if (uploadResponse != null && !string.IsNullOrEmpty(uploadResponse.URL))
                {
                    result.URL = uploadResponse.URL;
                    return result;
                }
                else
                {
                    Errors.Add($"Directus upload failed. Response: {result.Response}");
                }
            }

            return result;
        }
    }

    internal class DirectusSingleItemResponseWrapper
    {
        [JsonProperty("data")]
        public DirectusCaseData Data { get; set; }
    }

    internal class DirectusCaseData
    {
        [JsonProperty("archive")]
        public bool? Archive { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("patients")]
        public List<DirectusPatientData> Patients { get; set; }
    }

    internal class DirectusPatientData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("archive")]
        public bool Archive { get; set; }
    }

    internal class DirectusDicomUploadResponse
    {
        [JsonProperty("id")]
        public string URL { get; set; }

        [JsonProperty("patient_id")]
        public string PatientId { get; set; }
    }
}