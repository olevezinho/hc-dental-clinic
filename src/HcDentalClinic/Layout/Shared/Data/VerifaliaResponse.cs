using System.Text.Json.Serialization;

namespace HcDentalClinic.Layout.Shared.Data;

public class VerifaliaResponse
{
    [JsonPropertyName("overview")]
    public JobOverview Overview { get; set; } = null!;

    [JsonPropertyName("entries")]
    public EntriesContainer Entries { get; set; } = null!;
}

public class EntriesContainer
{
    [JsonPropertyName("data")]
    public List<VerifaliaEntry> Data { get; set; } = null!;
}

public class VerifaliaEntry
{
    [JsonPropertyName("inputData")]
    public string InputData { get; set; } = null!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("classification")]
    public string Classification { get; set; } = null!;
}

public class JobOverview
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;
}