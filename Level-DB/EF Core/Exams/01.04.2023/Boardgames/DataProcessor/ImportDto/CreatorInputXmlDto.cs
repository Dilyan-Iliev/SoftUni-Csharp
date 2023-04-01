namespace Boardgames.DataProcessor.ImportDto
{
    using Boardgames.Constants;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Creator")]
    public class CreatorInputXmlDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(GlobalConstants.CreatorNameMinLength)]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [MinLength(GlobalConstants.CreatorNameMinLength)]
        [MaxLength(GlobalConstants.CreatorNameMaxLength)]
        public string LastName { get; set; }

        [XmlArray("Boardgames")]
        public BoardgameInputXmlDto[] Boardgames { get; set; }
    }
}
