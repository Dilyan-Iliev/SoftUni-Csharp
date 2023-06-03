namespace HouseRentingSystem.Services.Services
{
    using HouseRentingSystem.Core.Data.Entities;
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.DTOs.House;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService
        : IHouseService
    {
        private readonly IRepository repo;

        public HouseService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> Add(AddHouseDto model, int agentId)
        {
            var house = new House()
            {
                Title = model.Title,
                Description = model.Description,
                Address = model.Address,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                CategoryId = model.CategoryId,
                AgentId = agentId,
            };

            await this.repo.AddAsync(house);
            await this.repo.SaveChangesAsync();

            return house.Id;
        }

        public async Task<bool> CategoryExists(int categoryId)
            => await this.repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);

        public async Task<ICollection<HouseCategoryDto>> GetHouseCategories()
        {
            return await this.repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new HouseCategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<ICollection<HouseDto>> GetLastThreeHouses()
        {
            return await this.repo.AllReadonly<House>()
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseDto()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
