using Newtonsoft.Json;
using ShareX.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShareX
{
    public static class SessionManager
    {
        private static readonly string DirectusBaseUrl = ConfigurationManager.AppSettings["DirectusBaseUrl"];
        private const string REFRESH_ENDPOINT = "/auth/refresh";

        private static readonly HttpClient client = new HttpClient();

        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }
        public static string UserId { get; set; }
        public static string UserEmail { get; set; }

        public static bool IsAuthenticated => !string.IsNullOrEmpty(AccessToken);

        public static void ResetSession()
        {
            AccessToken = null;
            RefreshToken = null;
            UserEmail = null;
            UserId = null;
            TokenManager.DeleteTokens();
        }

        public static async Task<(bool Success, string ErrorMessage)> RefreshSessionAsync()
        {
            if (string.IsNullOrEmpty(RefreshToken))
            {
                return (false, "Refresh token missing. Please sign in.");
            }

            try
            {
                var refreshData = new { refresh_token = RefreshToken, mode = "json" };
                string json = JsonConvert.SerializeObject(refreshData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.Timeout = TimeSpan.FromSeconds(30);

                HttpResponseMessage response = await client.PostAsync($"{DirectusBaseUrl}{REFRESH_ENDPOINT}", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<DirectusLoginResponse>(responseBody);

                    AccessToken = loginResponse.Data.AccessToken;
                    RefreshToken = loginResponse.Data.RefreshToken;

                    TokenManager.SaveTokens(AccessToken, RefreshToken, UserEmail, UserId);

                    return (true, null);
                }
                else
                {
                    ResetSession();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<DirectusErrorResponse>(responseBody);

                    if (errorResponse?.Errors?.Count > 0)
                    {
                        string errorMessage = errorResponse.Errors[0].Message;
                        return (false, $"Server error: {errorMessage}. Session cleared.");
                    }
                    else
                    {
                        return (false, $"Unknown server error. Code: {response.StatusCode}. Session cleared.");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return (false, "Request timeout");
            }
            catch (HttpRequestException ex)
            {
                return (false, $"Connection error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Unknown error: {ex.Message}");
            }
        }
    }

    public class DirectusErrorResponse
    {
        [JsonProperty("errors")]
        public List<ErrorData> Errors { get; set; }
    }

    public class ErrorData
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("extensions")]
        public Dictionary<string, object> Extensions { get; set; }
    }
}