namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Theatre.Data.Models;
    using Theatre.Utils;

    [XmlType("Cast")]
    public class CastInputXmlDto
    {
        [XmlElement("FullName")]
        [Required]
        [StringLength(GlobalConstants.CastFullNameMaxLength, MinimumLength = GlobalConstants.CastFullNameMinLength)]
        public string FullName { get; set; }

        [XmlElement("IsMainCharacter")]
        [Required]
        public bool IsMainCharacter { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(GlobalConstants.CastPhoneNumberRegex)]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
