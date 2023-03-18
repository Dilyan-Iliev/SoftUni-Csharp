namespace Footballers.DataProcessor.ExportDto
{
    using Newtonsoft.Json;

    [JsonObject]
    public class TeamFootballersOutputJsonModel
    {
        [JsonProperty("FootballerName")]
        public string Name { get; set; }

        [JsonProperty("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [JsonProperty("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [JsonProperty("BestSkillType")]
        public string BestSkillType { get; set; }

        [JsonProperty("PositionType")]
        public string PositionType { get; set; }
    }
}
