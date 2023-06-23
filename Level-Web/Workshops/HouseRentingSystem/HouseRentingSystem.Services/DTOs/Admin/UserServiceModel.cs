namespace HouseRentingSystem.Services.DTOs.Admin
{
    public class UserServiceModel
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? PhoneNumber { get; set; }
    }
}
