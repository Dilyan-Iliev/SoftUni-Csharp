namespace Theatre.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Play")]
    public class PlayOutputXmlDto
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }

        [XmlAttribute("Duration")]
        public string Duration { get; set; }

        [XmlAttribute("Rating")]
        public string Rating { get; set; }

        [XmlAttribute("Genre")]
        public string Genre { get; set; }

        [XmlArray("Actors")]
        public ActorOutputXmlDto[] Actors { get; set; }
    }
}
