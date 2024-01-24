using System.Text.Json.Serialization;

namespace EForsyning_API;

public class YearMark
{
    [JsonPropertyName("aarsmaerke")]
    public int Year { get; set; }

    [JsonPropertyName("aarsmaerke_start")]
    public string? StartDate { get; set; }

    [JsonPropertyName("aarsmaerke_slut")]
    public string? EndDate { get; set; }
}
