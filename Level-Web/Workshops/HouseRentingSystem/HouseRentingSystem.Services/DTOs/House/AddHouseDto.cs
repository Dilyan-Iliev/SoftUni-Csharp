namespace HouseRentingSystem.Services.DTOs.House
{
    using System.ComponentModel.DataAnnotations;

    public class AddHouseDto
    {
        public AddHouseDto()
        {
            this.Categories = new List<HouseCategoryDto>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(150, MinimumLength = 30)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 50)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), "0.00", "2000.0",
            ErrorMessage = "Price per month must be positive number and less than {2} lv.")]
        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryDto> Categories { get; set; }
    }
}
