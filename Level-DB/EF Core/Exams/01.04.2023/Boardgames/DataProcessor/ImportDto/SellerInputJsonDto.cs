namespace Boardgames.DataProcessor.ImportDto
{
    using Boardgames.Constants;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    [JsonObject]
    public class SellerInputJsonDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(GlobalConstants.SellerNameMinLength)]
        [MaxLength(GlobalConstants.SellerNameMaxlength)]
        public string Name { get; set; }

        [JsonProperty("Address")]
        [Required]
        [MinLength(GlobalConstants.SellerAddressMinLength)]
        [MaxLength(GlobalConstants.SellerNameMaxlength)]
        public string Address { get; set; }

        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; }

        [JsonProperty("Website")]
        [Required]
        [RegularExpression(GlobalConstants.SellerWebsiteRegex)]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; }
    }
}
