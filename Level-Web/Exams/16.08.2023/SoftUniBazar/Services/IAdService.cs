namespace SoftUniBazar.Services
{
    using SoftUniBazar.Data.Models;
    using SoftUniBazar.Models;

    public interface IAdService
    {
        Task<IEnumerable<AllAdsViewModel>> GetAllAdsAsync();

        Task<IEnumerable<SelectCategoryViewModel>> RetrieveCategoriesAsync();

        Task AddNewAdAsync(CreateAdViewModel model, string creatorId);

        Task<Ad> FindAdForEditAsync(int id);

        Task EditAdAsync(int id, EditAdViewModel model);

        Task<int> AddToCartAsync(int id, string userId);

        Task RemoveFromCartAsync(int id, string userId);

        Task<IEnumerable<CartViewModel>> GetAdsInCartAsync(string userId);
    }
}
