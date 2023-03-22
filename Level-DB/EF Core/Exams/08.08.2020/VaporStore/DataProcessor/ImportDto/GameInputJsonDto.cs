namespace VaporStore.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Constants;

    [JsonObject]
    public class GameInputJsonDto
    {
        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Range(typeof(decimal), GameConstants.GameMinPrice, GameConstants.GameMaxPrice)]
        public decimal Price { get; set; }

        [JsonProperty("ReleaseDate")]
        [Required]
        public string ReleaseDate { get; set; }

        [JsonProperty("Developer")]
        [Required]
        public string Developer { get; set; }

        [JsonProperty("Genre")]
        [Required]
        public string Genre { get; set; }

        [JsonProperty("Tags")]
        public string[] Tags { get; set; }
    }
}
