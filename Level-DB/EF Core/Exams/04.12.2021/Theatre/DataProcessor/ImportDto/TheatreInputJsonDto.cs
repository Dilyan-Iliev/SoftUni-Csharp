namespace Theatre.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using Theatre.Utils;

    [JsonObject]
    public class TheatreInputJsonDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(GlobalConstants.TheatreNameMaxLength, MinimumLength = GlobalConstants.TheatreNameMinLength)]
        public string Name { get; set; }

        [JsonProperty("NumberOfHalls")]
        [Range(GlobalConstants.TheatreMinNumberOfHalls, GlobalConstants.TheatreMaxNumberOfHalls)]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("Director")]
        [Required]
        [StringLength(GlobalConstants.TheatreDirectorNameMaxLength, MinimumLength = GlobalConstants.TheatreDirectorNameMinLength)]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public TicketInputJsonDto[] Tickets { get; set; }
    }
}
