using System.Text.Json.Serialization;

namespace EForsyning_API;

    public class UserInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("navn")]
        public string? Name { get; set; }

        [JsonPropertyName("navn2")]
        public string? Name2 { get; set; }

        [JsonPropertyName("vej")]
        public string? Street { get; set; }

        [JsonPropertyName("husnr")]
        public string? StreetNumber { get; set; }

        [JsonPropertyName("postnr")]
        public string? PostalCode { get; set; }

        [JsonPropertyName("bynavn")]
        public string? City { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("indflyttet")]
        public string? StartDate { get; set; }

        [JsonPropertyName("ejendomnr")]
        public int BuildingNumber { get; set; }

        [JsonPropertyName("ejerNavn")]
        public string? BuildingOwner { get; set; }
    }
