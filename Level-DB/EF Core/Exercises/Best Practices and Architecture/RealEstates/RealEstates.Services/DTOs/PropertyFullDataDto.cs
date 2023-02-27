namespace RealEstates.Services.DTOs
{
    using System.Xml.Serialization;

    [XmlType("Property")]
    public class PropertyFullDataDto
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlElement("Property-District")]
        public string DistrictName { get; set; }

        [XmlElement("Property-Size")]
        public int Size { get; set; }

        [XmlElement("Property-BuiltYear")]
        public int BuiltYear { get; set; }

        [XmlElement("Property-Price")]
        public int Price { get; set; }

        [XmlElement("Property-Type")]
        public string PropertyType { get; set; }

        [XmlElement("Property-BuildingType")]
        public string BuildingType { get; set; }

        [XmlArray("Property-Tags")]
        public TagInfoDto[] Tags { get; set; }
    }
}
