namespace Trucks.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class ClientsWithTrucksOutputJsonModel
    {
        [JsonProperty("Name")]
        public string ClientName { get; set; }

        [JsonProperty("Trucks")]
        public TruckInfoOutputJsonModel[] Trucks { get; set; }
    }
}
