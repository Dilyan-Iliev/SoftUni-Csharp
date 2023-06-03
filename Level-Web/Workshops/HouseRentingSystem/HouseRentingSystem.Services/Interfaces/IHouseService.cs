namespace HouseRentingSystem.Services.Interfaces
{
    using HouseRentingSystem.Services.DTOs.House;

    public interface IHouseService
    {
        //връща последните 3 къщи
        Task<ICollection<HouseDto>> GetLastThreeHouses();

        Task<ICollection<HouseCategoryDto>> GetHouseCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Add(AddHouseDto model, int agentId);
    }
}
