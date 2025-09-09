using Newtonsoft.Json;
using ShareX.UploadersLib.FileUploaders;
using System;
using System.Diagnostics;
using System.IO;

public static class TokenManager
{
    private static readonly string TokenFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "ShareX",
        "AuthTokens.json"
    );

    private class TokenData
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public static void SaveTokens(string accessToken, string refreshToken, string email)
    {
        var tokens = new TokenData
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Email = email
        };
        string json = JsonConvert.SerializeObject(tokens, Formatting.Indented);

        Directory.CreateDirectory(Path.GetDirectoryName(TokenFilePath));
        File.WriteAllText(TokenFilePath, json);
    }

    public static (string AccessToken, string RefreshToken, string Email) LoadTokens()
    {
        if (File.Exists(TokenFilePath))
        {
            try
            {
                string json = File.ReadAllText(TokenFilePath);
                var tokens = JsonConvert.DeserializeObject<TokenData>(json);

                if (tokens != null)
                {
                    return (tokens.AccessToken, tokens.RefreshToken, tokens.Email);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error reading tokens: {ex.Message}");
            }
        }

        return (null, null, null);
    }

    public static void DeleteTokens()
    {
        if (File.Exists(TokenFilePath))
        {
            File.Delete(TokenFilePath);
        }
    }
}