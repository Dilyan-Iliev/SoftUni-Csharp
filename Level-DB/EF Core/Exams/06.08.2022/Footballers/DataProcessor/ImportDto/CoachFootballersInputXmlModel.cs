namespace Footballers.DataProcessor.ImportDto
{
    using Footballers.GlobalConstants;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Footballer")]
    public class CoachFootballersInputXmlModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ModelConstants.FootballerNameMinLength)]
        [MaxLength(ModelConstants.FootballerNameMaxLength)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        [Range(0, 4)]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required]
        [Range(0, 3)]
        public int PositionType { get; set; }
    }
}
