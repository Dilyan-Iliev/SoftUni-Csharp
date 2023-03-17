namespace Trucks.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class TruckInfoOutputJsonModel
    {
        [JsonProperty("TruckRegistrationNumber")]
        public string TruckRegistrationNumber { get; set; }

        [JsonProperty("VinNumber")]
        public string VinNumber { get; set; }

        [JsonProperty("TankCapacity")]
        public int TankCapacity { get; set; }

        [JsonProperty("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [JsonProperty("CategoryType")]
        public string CategoryType { get; set; }

        [JsonProperty("MakeType")]
        public string MakeType { get; set; }
    }
}
