using Newtonsoft.Json;


public class DirectusTokenData
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
}

public class DirectusLoginResponse
{
    [JsonProperty("data")]
    public DirectusTokenData Data { get; set; }

    [JsonIgnore]
    public string UserId { get; set; }
}

public class DirectusUserMeResponse
{
    [JsonProperty("data")]
    public DirectusUser Data { get; set; }
}

public class DirectusUser
{
    [JsonProperty("id")]
    public string Id { get; set; }
}

public class DirectusErrorDetail
{
    [JsonProperty("message")]
    public string Message { get; set; }
}

public class DirectusErrorResponse
{
    [JsonProperty("errors")]
    public DirectusErrorDetail[] Errors { get; set; }
}