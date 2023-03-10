namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    [JsonObject]
    public class SupplierModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isImporter")]
        public bool IsImporter { get; set; }
    }
}
