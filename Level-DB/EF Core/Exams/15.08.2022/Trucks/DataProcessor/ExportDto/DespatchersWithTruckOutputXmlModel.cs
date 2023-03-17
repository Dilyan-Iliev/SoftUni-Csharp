namespace Trucks.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Despatcher")]
    public class DespatchersWithTruckOutputXmlModel
    {
        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; }

        [XmlArray("Trucks")]
        public TrucksInfoOutputXmlModel[] Trucks { get; set; }
    }
}
