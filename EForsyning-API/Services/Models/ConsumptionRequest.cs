using System.Text.Json.Serialization;

namespace EForsyning_API;

public class ConsumptionRequest
{
    [JsonPropertyName("AHoejDetail")]
    public bool HighDetail { get; set; } = false;

    [JsonPropertyName("AarsMaerke")]
    public int Year { get; set; }

    [JsonPropertyName("AflaesningsFilterDag")]
    public string ReadingFilterDay { get; set; } = "ULTIMO";

    [JsonPropertyName("AflaesningsUdjaevning")]
    public bool ReadingEqualization { get; set; } = true;

    [JsonPropertyName("Aflaesningsfilter")]
    public string ReadingFilter { get; set; } = "afDagsvis";

    [JsonPropertyName("AktivNr")]
    public int AssetNumber { get; set; }

    [JsonPropertyName("Belastningsfaktor")]
    public string LoadFactor { get; set; } = "0";

    [JsonPropertyName("BestemtEnhed")]
    public string DefinedUnit { get; set; } = "0";

    [JsonPropertyName("Ejendomnr")]
    public int BuildingNumber { get; set; }

    [JsonPropertyName("ForbrugsAfgraensning_FraAfl_nr")]
    public string ForbrugsAfgraensning_FraAfl_nr { get; set; } = "0";

    [JsonPropertyName("ForbrugsAfgraensning_FraAflaesning")]
    public string ForbrugsAfgraensning_FraAflaesning { get; set; } = "0";

    [JsonPropertyName("ForbrugsAfgraensning_FraDato")]
    public string ForbrugsAfgraensning_FraDato { get; set; } = "0";

    [JsonPropertyName("ForbrugsAfgraensning_FraMellNr")]
    public string ForbrugsAfgraensning_FraMellNr { get; set; } = "0";

    [JsonPropertyName("ForbrugsAfgraensning_MedtagMellemliggendeMellemaflas")]
    public bool ForbrugsAfgraensning_MedtagMellemliggendeMellemaflas { get; set; } = true;

    [JsonPropertyName("ForbrugsAfgraensning_TilAfl_nr")]
    public string ForbrugsAfgraensning_TilAfl_nr { get; set; } = "0";

    [JsonPropertyName("ForbrugsAfgraensning_TilAflaesning")]
    public string ForbrugsAfgraensning_TilAflaesning { get; set; } = "2";

    [JsonPropertyName("ForbrugsAfgraensning_TilDato")]
    public string ForbrugsAfgraensning_TilDato { get; set; } = "0";

    [JsonPropertyName("ForbrugsAfgraensning_TilJournalNr")]
    public string ForbrugsAfgraensning_TilJournalNr { get; set; } = "0";

    [JsonPropertyName("ForbrugsAfgraensning_TilMellnr")]
    public string ForbrugsAfgraensning_TilMellnr { get; set; } = "0";

    [JsonPropertyName("Godkendelser")]
    public string Godkendelser { get; set; } = "0";

    [JsonPropertyName("I_Nr")]
    public int InstallationNumber { get; set; }

    [JsonPropertyName("MedForventetForbrug")]
    public bool WithExpectedConsumption { get; set; } = true;

    [JsonPropertyName("OmregnForbrugTilAktuelleEnhed")]
    public bool CalculateConsumptionToActualUnits { get; set; } = true;

    [JsonPropertyName("Optioner")]
    public string Options { get; set; } = "foSkabDetaljer, foBestemtBeboer, foMedtagWebAflaes";

    [JsonPropertyName("RadEksponent1")]
    public string RadEksponent1 { get; set; } = "0";

    [JsonPropertyName("RadEksponent2")]
    public string RadEksponent2 { get; set; } = "0";

    [JsonPropertyName("SletFiltreredeAflaesninger")]
    public bool DeleteFilteredReadings { get; set; } = true;

    [JsonPropertyName("aCallKey")]
    public int aCallKey { get; set; } = 0;
}