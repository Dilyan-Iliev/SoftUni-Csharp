namespace HouseRentingSystem.Services.DTOs.House
{
    using HouseRentingSystem.Services.DTOs.Agent;

    public class HouseDetailsDto
        : HouseServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public AgentServiceModel Agent { get; set; }
    }
}
