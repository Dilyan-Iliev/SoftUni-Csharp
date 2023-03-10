namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CustomerModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
