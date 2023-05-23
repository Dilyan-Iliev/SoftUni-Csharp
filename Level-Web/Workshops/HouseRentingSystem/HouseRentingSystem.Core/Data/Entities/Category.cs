namespace HouseRentingSystem.Core.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static HouseRentingSystem.Common.DataConstants.CategoryConstants;

    public class Category
    {
        public Category()
        {
            this.Houses = new HashSet<House>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<House> Houses { get; set; }
    }
}
