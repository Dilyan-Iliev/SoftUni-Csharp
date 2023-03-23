namespace VaporStore.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Constants;

    [JsonObject]
    public class CardInputJsonDto
    {
        [JsonProperty("Number")]
        [Required]
        [RegularExpression(CardConstants.CardNumberRegex)]
        public string Number { get; set; }

        [JsonProperty("CVC")]
        [Required]
        [RegularExpression(CardConstants.CardCvcRegex)]
        public string Cvc { get; set; }

        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; }
    }
}
