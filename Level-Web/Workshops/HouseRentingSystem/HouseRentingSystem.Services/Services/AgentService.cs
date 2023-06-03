namespace HouseRentingSystem.Services.Services
{
    using HouseRentingSystem.Core.Data.Entities;
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class AgentService
        : IAgentService
    {
        private readonly IRepository repo;

        public AgentService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            var newAgent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await this.repo.AddAsync<Agent>(newAgent);
            await this.repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
            => await this.repo.All<Agent>()
                .AnyAsync(a => a.UserId == userId);

        public async Task<int> GetAgentId(string userId)
        {
            return (await this.repo.AllReadonly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }

        public async Task<bool> UserHasRentsAsync(string userId)
            => await this.repo.All<House>()
                .AnyAsync(h => h.RenterId == userId);

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
            => await this.repo.All<Agent>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
    }
}
