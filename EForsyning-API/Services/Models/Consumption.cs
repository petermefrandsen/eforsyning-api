using System.Text.Json.Serialization;

namespace EForsyning_API;

public class Consumption 
{
    [JsonPropertyName("TempRetur")]
    public string ReturnTemperature { get; set; }

    [JsonPropertyName("Forv_Retur")]
    public string ExpectedReturnTemperature { get; set; }

    [JsonPropertyName("Afl_Nr")]
    public string Afl_Nr { get; set; }

    [JsonPropertyName("AntTaellevaerker")]
    public string AntTaellevaerker { get; set; }

    [JsonPropertyName("TilDatoStr")]
    public string Date { get; set; }

    [JsonPropertyName("TForbrugsTaellevaerk")]
    public List<ConsumptionSpecification> ConsumptionSpecifications { get; set; }

    [JsonPropertyName("Elek_MalNr")]
    public string MeterNumber { get; set; }

    [JsonPropertyName("Aflas_kilde_text")]
    public string ReadingDescription { get; set; }

    [JsonPropertyName("Tempfrem")]
    public string DeliveredTemperature { get; set; }

    [JsonPropertyName("ForventetForbrugM3")]
    public string ExpectedConsumptionM3 { get; set; }

    [JsonPropertyName("ForventetForbrugENG1")]
    public string ExpectedConsumptionENG1 { get; set; }

    [JsonPropertyName("Afkoling")]
    public string Afkoling { get; set; }
}

public class ConsumptionSpecification
    {
        [JsonPropertyName("IndexNavn")]
        public string SpecificationName { get; set; }

        [JsonPropertyName("Enhed_Txt")]
        public string UnitDescription { get; set; }

        [JsonPropertyName("Korrig")]
        public string Korrig { get; set; }

        [JsonPropertyName("Beskrivelse")]
        public string Description { get; set; }

        [JsonPropertyName("Enhed")]
        public string Unit { get; set; }

        [JsonPropertyName("Faktor")]
        public string Factor { get; set; }

        [JsonPropertyName("Slut")]
        public string End { get; set; }

        [JsonPropertyName("Start")]
        public string Start { get; set; }

        [JsonPropertyName("Format")]
        public string Format { get; set; }

        [JsonPropertyName("Forbrug")]
        public string Consumption { get; set; }
    }

public class ConsumptionLineSummary
{
    [JsonPropertyName("AktuelLinjeNr")]
    public string AktuelLinjeNr { get; set; }

    [JsonPropertyName("AntLinjer")]
    public string AntLinjer { get; set; }

    [JsonPropertyName("TForbrugsLinje")]
    public List<Consumption> ConsumptionLines { get; set; }
}

public class ConsumptionResponse
{
    [JsonPropertyName("ForbrugsLinjer")]
    public ConsumptionLineSummary ConsumptionLineSummary { get; set; }
}