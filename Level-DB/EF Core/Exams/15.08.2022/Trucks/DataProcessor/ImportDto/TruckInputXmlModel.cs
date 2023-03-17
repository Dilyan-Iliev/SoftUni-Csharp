namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Data.Models.Enums;
    using GlobalConstants;

    [XmlType("Truck")]
    public class TruckInputXmlModel
    {
        [XmlElement("RegistrationNumber")]
        [Required]
        [RegularExpression(ModelContants.RegistrationNumberRegex)]
        public string RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required]
        [RegularExpression(ModelContants.VinNumberRegex)]
        public string VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(ModelContants.TruckMinTankCapacity, ModelContants.TruckMaxTankCapacity)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(ModelContants.TruckMinCargoCapacity, ModelContants.TruckMaxCargoCapacity)]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Required]
        [Range(0, 4)]
        public int CategoryType { get; set; } //? or int

        [XmlElement("MakeType")]
        [Required]
        [Range(0, 5)]
        public int MakeType { get; set; } //? or int
    }
}
