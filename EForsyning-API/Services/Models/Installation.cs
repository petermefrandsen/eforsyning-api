using System.Text.Json.Serialization;

namespace EForsyning_API;

public class Installation
{
    [JsonPropertyName("EjendomNr")]
    public int EjendomNr { get; set; }

    [JsonPropertyName("Adresse")]
    public string? Address { get; set; }

    [JsonPropertyName("InstallationNr")]
    public int InstallationNumber { get; set; }

    [JsonPropertyName("ForbrugerNr")]
    public string? ConsumerNumber { get; set; }

    [JsonPropertyName("MålerNr")]
    public string? MeterNumber { get; set; }

    [JsonPropertyName("By")]
    public string? City { get; set; }

    [JsonPropertyName("PostNr")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("AktivNr")]
    public int AssetNumber { get; set; }

    [JsonPropertyName("Målertype")]
    public string? MeterType { get; set; }
}

public class UserInstallationsResponse
{
    [JsonPropertyName("Installationer")]
    public required List<Installation> Installations { get; set; }
}