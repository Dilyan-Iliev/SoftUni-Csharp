namespace HouseRentingSystem.Services.Interfaces
{
    using HouseRentingSystem.Services.DTOs.Statistics;

    public interface IStatisticsService
    {
        Task<StatisticsServiceModel> Total();
    }
}
