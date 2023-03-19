namespace Artillery.DataProcessor.ImportDto
{
    using Utils;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Shell")]
    public class ShellInputXmlDto
    {
        [XmlElement("ShellWeight")]
        [Range(GlobalConstants.ShellMinWeight, GlobalConstants.ShellMaxWeight)]
        public double ShellWeight { get; set; }

        [XmlElement("Caliber")]
        [Required]
        [MinLength(GlobalConstants.ShellCaliberMinLength)]
        [MaxLength(GlobalConstants.ShellCaliberMaxLength)]
        public string Caliber { get; set; }
    }
}
