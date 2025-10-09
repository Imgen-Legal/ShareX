using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using static ShareX.UploadersLib.ImageUploaders.TwitPicUploader.TwitPicResponse;

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
                CapturedBy = config.DirectusSessionUser,
                Metadata = config.DirectusSessionMetadata
            };
        }
    }

    public class DirectusUploader : ImageUploader
    {
        private static readonly string DirectusBaseUrl = ConfigurationManager.AppSettings["DirectusBaseUrl"];
        private static readonly string ScreenshotUploadEndpoint = "/custom/upload-dicom-screenshot";
        private static readonly string UploadUrl = DirectusBaseUrl + ScreenshotUploadEndpoint;

        public string PatientId { get; set; }
        public string Metadata { get; set; }
        public string AccessToken { get; set; }
        public string CapturedBy { get; set; }

        public override UploadResult Upload(Stream stream, string fileName)
        {
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

    public class DirectusDicomUploadResponse
    {
        // There is no exact URL in the response, ID used for filling
        [JsonProperty("id")]
        public string URL { get; set; }

        [JsonProperty("patient_id")]
        public string PatientId { get; set; }
    }
}
