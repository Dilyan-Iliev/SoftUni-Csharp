namespace HouseRentingSystem.Services.Interfaces.Admin
{
    using HouseRentingSystem.Services.DTOs.Admin;

    public interface IUserService
    {
        Task<string> UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> All();
    }
}
