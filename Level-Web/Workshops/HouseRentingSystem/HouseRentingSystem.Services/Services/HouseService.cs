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

        public async Task<HouseQueryModel> All(string? category = null, string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new HouseQueryModel();

            var houses = repo.AllReadonly<House>(); //returns IQueryable (expression tree)

            if (!string.IsNullOrEmpty(category))
            {
                houses = houses
                    .Where(h => h.Category.Name == category); //returns IQueryable
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%"; //will be used in LIKE operation

                houses = houses
                    .Where(h => EF.Functions.Like(h.Title, searchTerm)
                    || EF.Functions.Like(h.Address, searchTerm)
                    || EF.Functions.Like(h.Description, searchTerm));
                //implementation of SQL LIKE operation
            }

            houses = sorting
                switch
            {
                HouseSorting.Price => houses
                    .OrderBy(h => h.PricePerMonth),

                HouseSorting.NotRentedFirst => houses
                    .OrderBy(h => h.RenterId),

                _ => houses.OrderByDescending(h => h.Id) //this is default case
            };

            result.Houses = await houses
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                })
                .ToListAsync();

            result.TotalHouses = await houses.CountAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await this.repo
                .AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
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
