namespace HouseRentingSystem.Services.Services
{
    using HouseRentingSystem.Core.Data.Entities;
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.DTOs.Statistics;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class StatisticsService
        : IStatisticsService
    {
        private readonly IRepository repo;

        public StatisticsService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<StatisticsServiceModel> Total()
        {
            int totalHouses = await this.repo
                .AllReadonly<House>()
                .CountAsync(h => h.IsActive);

            int totalRents = await this.repo
                .AllReadonly<House>()
                .CountAsync(h => h.RenterId != null && h.IsActive);

            return new StatisticsServiceModel()
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
    }
}
