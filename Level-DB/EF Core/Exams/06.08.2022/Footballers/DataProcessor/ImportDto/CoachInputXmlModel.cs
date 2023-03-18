namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.GlobalConstants;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class CoachInputXmlModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ModelConstants.CoachNameMinLength)]
        [MaxLength(ModelConstants.CoachNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("Nationality")]
        [Required]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public CoachFootballersInputXmlModel[] Footballers { get; set; }
    }
}
