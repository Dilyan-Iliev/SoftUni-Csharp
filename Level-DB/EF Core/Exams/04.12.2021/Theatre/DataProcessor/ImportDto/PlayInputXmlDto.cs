namespace Theatre.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Theatre.Utils;

    [XmlType("Play")]
    public class PlayInputXmlDto
    {
        [XmlElement("Title")]
        [Required]
        [StringLength(GlobalConstants.PlayTitleMaxLength, MinimumLength = GlobalConstants.PlayTitleMinLength)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Raiting")]
        [Range(GlobalConstants.PlayMinRating, GlobalConstants.PlayMaxRating)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        [StringLength(GlobalConstants.PlayDescriptionMaxLength)]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [StringLength(GlobalConstants.PlayScreenWriterNameMaxLength, MinimumLength = GlobalConstants.PlayScreenWriterNameMinLength)]
        public string Screenwriter { get; set; }
    }
}
