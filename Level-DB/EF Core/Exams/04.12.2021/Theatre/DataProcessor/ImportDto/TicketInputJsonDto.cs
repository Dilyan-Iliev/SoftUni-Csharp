namespace Theatre.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using Theatre.Utils;

    [JsonObject]
    public class TicketInputJsonDto
    {
        [JsonProperty("Price")]
        [Range(typeof(decimal), "1.00", "100.00")]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]
        [Range(GlobalConstants.TicketMinRowNumber, GlobalConstants.TicketMaxRowNumber)]
        public sbyte RowNumber { get; set; }

        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
