namespace Artillery.DataProcessor.ImportDto
{
    using Artillery.Utils;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Country")]
    public class CountryInputXmlDto
    {
        [XmlElement("CountryName")]
        [Required]
        [MinLength(GlobalConstants.CountryNameMinLength)]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        public string CountryName { get; set; }

        [XmlElement("ArmySize")]
        [Range(GlobalConstants.CountryArmSizeMinLength, GlobalConstants.CountryArmSizeMaxLength)]
        public int ArmySize { get; set; }
    }
}
