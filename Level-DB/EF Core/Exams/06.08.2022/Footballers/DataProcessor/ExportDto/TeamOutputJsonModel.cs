namespace Footballers.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class TeamOutputJsonModel
    {
        [JsonProperty("Name")]
        public string TeamName { get; set; }

        [JsonProperty("Footballers")]
        public TeamFootballersOutputJsonModel[] Footballers { get; set; }
    }
}
