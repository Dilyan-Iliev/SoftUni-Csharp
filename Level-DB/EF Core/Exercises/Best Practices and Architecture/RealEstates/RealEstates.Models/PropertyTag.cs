namespace RealEstates.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class PropertyTag
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
