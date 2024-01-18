using System.Text.Json.Serialization;

namespace EForsyning_API;

public class VaerkSettings
{
    [JsonPropertyName("AppServerUri")]
    public string? AppServerUri { get; set; }

    [JsonPropertyName("EforsyningUri")]
    public string? EforsyningUri { get; set; }

    [JsonPropertyName("WebsiteUri")]
    public string? WebsiteUri { get; set; }

    [JsonPropertyName("FirmaInfo")]
    public FirmaInfo? FirmaInfo { get; set; }

    [JsonPropertyName("LogoUrl")]
    public string? LogoUrl { get; set; }

    [JsonPropertyName("HarWebSide")]
    public bool HarWebSide { get; set; }

    [JsonPropertyName("ForsyningsNavn")]
    public string? ForsyningsNavn { get; set; }

    [JsonPropertyName("EForsyningId")]
    public int EForsyningId { get; set; }

    [JsonPropertyName("GoogleAnalytics")]
    public string? GoogleAnalytics { get; set; }

    [JsonPropertyName("RedirectSide")]
    public object? RedirectSide { get; set; }

    [JsonPropertyName("BrugRedirect")]
    public bool BrugRedirect { get; set; }

    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Navn")]
    public string? Navn { get; set; }

    [JsonPropertyName("ForsyningId")]
    public string? ForsyningId { get; set; }
}

public class FirmaInfo
{
    [JsonPropertyName("firmaNavn")]
    public string? FirmaNavn { get; set; }

    [JsonPropertyName("adresse")]
    public string? Adresse { get; set; }

    [JsonPropertyName("postNr")]
    public string? PostNr { get; set; }

    [JsonPropertyName("by")]
    public string? By { get; set; }

    [JsonPropertyName("land")]
    public string? Land { get; set; }

    [JsonPropertyName("telefonNr")]
    public string? TelefonNr { get; set; }

    [JsonPropertyName("vagtTelefonNr")]
    public string? VagtTelefonNr { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("cvrNr")]
    public string? CvrNr { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
}