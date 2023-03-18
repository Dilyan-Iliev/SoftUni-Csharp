namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.GlobalConstants;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    [JsonObject]
    public class TeamInputJsonModel
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ModelConstants.TeamNameMinLength)]
        [MaxLength(ModelConstants.TeamNameMaxLength)]
        [RegularExpression(ModelConstants.TeamNameRegex)]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(ModelConstants.TeamNationalityMinLength)]
        [MaxLength(ModelConstants.TeamNationalityMaxLength)]
        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] FootballersIds { get; set; }
    }
}
