using Newtonsoft.Json;
using System.Collections.Generic;

public class DirectusCase
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("status")]
    public string Status { get; set; }
}

public class DirectusPatient
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
    [JsonProperty("middle_name")]
    public string MiddleName{ get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }
    [JsonProperty("case_id")]
    public DirectusCase Case { get; set; }
}

public class DirectusResponseMeta
{
    [JsonProperty("total_count")]
    public int TotalCount { get; set; }
}

public class DirectusPatientResponse
{
    [JsonProperty("data")]
    public List<DirectusPatient> Data { get; set; }
    [JsonProperty("meta")]
    public DirectusResponseMeta Meta { get; set; }
}

public class CaseDisplayModel
{
    public string CaseId { get; set; }
    public string CaseName { get; set; }
    public string Status { get; set; }
    public string PatientName { get; set; }

    public string PatientMiddleName { get; set; }
    public string PatientLastName { get; set; }
    public DirectusCase OriginalCase { get; set; }
    public DirectusPatient OriginalPatient { get; set; }
}
