namespace RealEstates.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Property //т.е. имот
    {
        public Property()
        {
            this.PropertiesTags = new HashSet<PropertyTag>();   
        }

        public int Id { get; set; }

        public int Size { get; set; }

        public int? YardSize { get; set; } //in case YardSize is null

        public byte? Floor { get; set; } //in case Floor is null

        public byte? TotalFloors { get; set; } //in case TotalFloors is null

        public int? BuiltYear { get; set; }

        public int? Price { get; set; } //whole number in EUR

        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        [ForeignKey(nameof(PropertyType))]
        public int PropertyTypeId { get; set; }

        public virtual PropertyType PropertyType { get; set; }

        [ForeignKey(nameof(BuildingType))]
        public int BuildingTypeId { get; set; }

        public virtual BuildingType BuildingType { get; set; }

        public virtual ICollection<PropertyTag> PropertiesTags { get; set; }
    }
}
