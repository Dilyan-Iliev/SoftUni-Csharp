namespace Footballers.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class CoachOutputXmlModel
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        public string Name { get; set; }

        [XmlArray("Footballers")]
        public CoachFootballersOutputXmlModel[] Footballers { get; set; }
    }
}
