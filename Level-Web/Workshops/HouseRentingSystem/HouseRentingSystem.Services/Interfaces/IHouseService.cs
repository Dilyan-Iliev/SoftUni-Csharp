namespace HouseRentingSystem.Services.Interfaces
{
    using HouseRentingSystem.Services.DTOs.House;

    public interface IHouseService
    {
        Task<ICollection<HouseDto>> GetLastThreeHouses();

        Task<ICollection<HouseCategoryDto>> GetHouseCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Add(AddHouseDto model, int agentId);

        Task<HouseQueryModel> All(string? category = null, string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int id);

        Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId);

        Task<HouseDetailsDto> HouseDetailsById(int id);

        Task<bool> Exists(int id);

        Task Edit(int houseId, AddHouseDto model);

        Task<bool> HasAgentWithId(int houseId, string currentUserId);

        Task<int> GetHouseCategoryId(int houseId);

        Task Delete(int houseId);

        Task<bool> IsRented(int houseId);

        Task<bool> IsRentedByUserWithId(string userId, int houseId);

        Task Rent(int houseId, string userId);

        Task Leave(int houseId);
    }
}
