namespace VaporStore.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using VaporStore.Constants;

    [XmlType("Purchase")]
    public class PurchaseInputXmlDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(PurchaseConstants.PurchaseProductKeyRegex)]
        public string Key { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression(CardConstants.CardNumberRegex)]
        public string Card { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }
    }
}
