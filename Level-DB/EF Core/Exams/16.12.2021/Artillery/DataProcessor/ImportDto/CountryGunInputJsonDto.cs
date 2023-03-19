namespace Artillery.DataProcessor.ImportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CountryGunInputJsonDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
