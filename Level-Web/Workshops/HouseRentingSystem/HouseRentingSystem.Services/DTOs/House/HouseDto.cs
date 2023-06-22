namespace HouseRentingSystem.Services.DTOs.House
{
    using HouseRentingSystem.Services.Interfaces;

    public class HouseDto : IHouseModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Address { get; init; } = null!;
    }
}
