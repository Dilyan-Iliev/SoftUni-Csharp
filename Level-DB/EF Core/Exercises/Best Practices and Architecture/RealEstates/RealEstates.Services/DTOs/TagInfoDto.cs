namespace RealEstates.Services.DTOs
{
    using System.Xml.Serialization;

    [XmlType("Tag")]
    public class TagInfoDto
    {
        [XmlElement("Tag-Name")]
        public string Name { get; set; }
    }
}
