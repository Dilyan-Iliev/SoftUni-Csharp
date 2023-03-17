namespace Trucks.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using Trucks.GlobalConstants;

    [JsonObject]
    public class ClientInputJsonModel
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ModelContants.ClientNameMinLength)]
        [MaxLength(ModelContants.ClientNameMaxLength)]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required]
        [MinLength(ModelContants.ClientNationalityMinLength)]
        [MaxLength(ModelContants.ClientNationalityMaxLength)]
        public string Nationality { get; set; }

        [JsonProperty("Type")]
        [Required]
        public string Type { get; set; }

        [JsonProperty("Trucks")]
        public int[] Trucks { get; set; }
    }
}
