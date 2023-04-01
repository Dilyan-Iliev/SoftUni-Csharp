namespace Boardgames.DataProcessor.ImportDto
{
    using Boardgames.Constants;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Boardgame")]
    public class BoardgameInputXmlDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.BoardgameNameMinLength)]
        [MaxLength(GlobalConstants.BoardgameNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("Rating")]
        [Range(GlobalConstants.BoardgameMinRating, GlobalConstants.BoardgameMaxRating)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Range(GlobalConstants.BoardgameMinYearPublished, GlobalConstants.BoardgameMaxYearPublished)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Range(0, 4)]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; }
    }
}
