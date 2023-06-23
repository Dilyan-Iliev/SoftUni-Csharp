namespace HouseRentingSystem.Areas.Admin.Models
{
    using HouseRentingSystem.Services.DTOs.House;

    public class MyHousesViewModel
    {
        public MyHousesViewModel()
        {
            this.AddedHouses = new List<HouseServiceModel>();
            this.RentedHouses = new List<HouseServiceModel>();
        }

        public IEnumerable<HouseServiceModel> AddedHouses { get; set; }

        public IEnumerable<HouseServiceModel> RentedHouses { get; set; }
    }
}
