namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Trucks.GlobalConstants;

    [XmlType("Despatcher")]
    public class DespatcherInputXmlModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ModelContants.DespatcherNameMinLength)]
        [MaxLength(ModelContants.DespatcherNameMaxLength)]
        public string DespatcherName { get; set; }

        [XmlElement("Position")]
        public string DespatcherPosition { get; set; }

        [XmlArray("Trucks")]
        public TruckInputXmlModel[] Trucks { get; set; }
    }
}
