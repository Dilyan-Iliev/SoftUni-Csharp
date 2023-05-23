namespace HouseRentingSystem.Services.Interfaces
{
    using HouseRentingSystem.Services.DTOs.House;

    public interface IHouseService
    {
        //връща последните 3 къщи
        Task<ICollection<HouseDto>> GetLastThreeHouses();
    }
}
