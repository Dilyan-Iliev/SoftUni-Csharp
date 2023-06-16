namespace HouseRentingSystem.Services.DTOs.House
{
    public class HouseQueryModel
    {
        public HouseQueryModel()
        {
            this.Houses = new List<HouseServiceModel>();
        }

        public int TotalHouses { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; }
    }
}
