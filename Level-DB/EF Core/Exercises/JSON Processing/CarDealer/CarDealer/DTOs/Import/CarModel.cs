namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CarModel
    {
        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("traveledDistance")]
        public long TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public int[] PartsId { get; set; }
    }
}
