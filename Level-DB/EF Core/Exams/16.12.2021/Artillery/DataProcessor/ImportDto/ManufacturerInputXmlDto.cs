namespace Artillery.DataProcessor.ImportDto
{
    using Artillery.Utils;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Manufacturer")]
    public class ManufacturerInputXmlDto
    {
        [Required]
        [MinLength(GlobalConstants.ManufacturerNameMinLength)]
        [MaxLength(GlobalConstants.ManufacturerNameMaxLength)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [Required]
        [MinLength(GlobalConstants.ManufactuterFoundedMinLength)]
        [MaxLength(GlobalConstants.ManufactuterFoundedMaxLength)]
        [XmlElement("Founded")]
        public string Founded { get; set; }
    }
}
