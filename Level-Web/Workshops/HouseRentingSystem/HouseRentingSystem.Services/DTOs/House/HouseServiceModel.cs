namespace HouseRentingSystem.Services.DTOs.House
{
    using HouseRentingSystem.Services.Interfaces;
    using System.ComponentModel.DataAnnotations;

    public class HouseServiceModel : IHouseModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Address { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Price per month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Is rented")]
        public bool IsRented { get; set; }
    }
}
