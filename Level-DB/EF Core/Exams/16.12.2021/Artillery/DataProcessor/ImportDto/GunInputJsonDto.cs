namespace Artillery.DataProcessor.ImportDto
{
    using Utils;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    [JsonObject]
    public class GunInputJsonDto
    {
        [JsonProperty("ManufacturerId")]
        public int ManufacturerId { get; set; }

        [JsonProperty("GunWeight")]
        [Range(GlobalConstants.GunMinWeight, GlobalConstants.GunMaxWeight)]
        public int GunWeight { get; set; }

        [JsonProperty("BarrelLength")]
        [Range(GlobalConstants.GunBarrelMinLength, GlobalConstants.GunBarrelMaxLength)]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }

        [JsonProperty("Range")]
        [Range(GlobalConstants.GunMinRange, GlobalConstants.GunMaxRange)]
        public int Range { get; set; }

        [JsonProperty("GunType")]
        [Required]
        public string GunType { get; set; }

        [JsonProperty("ShellId")]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public CountryGunInputJsonDto[] Countries { get; set; }
    }
}
