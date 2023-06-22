namespace HouseRentingSystem.Services.Services
{
    using HouseRentingSystem.Core.Data.Entities;
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.DTOs.House;
    using HouseRentingSystem.Services.Exceptions;
    using HouseRentingSystem.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class HouseService
        : IHouseService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;
        private readonly ILogger<HouseService> logger;

        public HouseService(IRepository repo, IGuard guard, ILogger<HouseService> logger)
        {
            this.repo = repo;
            this.guard = guard;
            this.logger = logger;
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

            try
            {
                await this.repo.AddAsync(house);
                await this.repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this.logger.LogError(nameof(Add), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return house.Id;
        }

        public async Task<HouseQueryModel> All(string? category = null, string? searchTerm = null,
            HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new HouseQueryModel();

            var houses = repo.AllReadonly<House>()
                .Where(h => h.IsActive); //returns IQueryable (expression tree)

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

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int id)
        {
            var agentHouses = await this.repo
                .AllReadonly<House>()
                .Where(h => h.IsActive)
                .Where(h => h.AgentId == id)
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title,
                    IsRented = h.RenterId != null
                })
                .ToListAsync();

            return agentHouses;
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId)
        {
            var userHouses = await this.repo
                .AllReadonly<House>()
                .Where(h => h.IsActive)
                .Where(h => h.RenterId == userId)
                .Select(h => new HouseServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title,
                    IsRented = h.RenterId != null
                })
                .ToListAsync();

            return userHouses;
        }

        public async Task<bool> CategoryExists(int categoryId)
            => await this.repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);

        public async Task Delete(int houseId)
        {
            var house = await this.repo
                .GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.IsActive = false;
                await this.repo.SaveChangesAsync();
            }
        }

        public async Task Edit(int houseId, AddHouseDto model)
        {
            var house = await this.repo
                .GetByIdAsync<House>(houseId);

            house.Title = model.Title;
            house.Description = model.Description;
            house.PricePerMonth = model.PricePerMonth;
            house.Address = model.Address;
            house.ImageUrl = model.ImageUrl;
            house.CategoryId = model.CategoryId;

            await this.repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await this.repo
                .AllReadonly<House>()
                .AnyAsync(h => h.Id == id && h.IsActive);
        }

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

        public async Task<int> GetHouseCategoryId(int houseId)
        {
            return (await this.repo
                .GetByIdAsync<House>(houseId)).CategoryId;
        }

        public async Task<ICollection<HouseDto>> GetLastThreeHouses()
        {
            return await this.repo.AllReadonly<House>()
                .Where(h => h.IsActive)
                .OrderByDescending(h => h.Id)
                .Select(h => new HouseDto()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                    Address = h.Address
                })
                .Take(3)
                .ToListAsync();
        }

        public async Task<bool> HasAgentWithId(int houseId, string currentUserId)
        {
            bool result = false;

            var house = await this.repo
                .AllReadonly<House>()
                .Where(h => h.IsActive)
                .Where(h => h.Id == houseId)
                .Include(h => h.Agent)
                .FirstOrDefaultAsync();

            if (house?.Agent != null
                && house.Agent.UserId == currentUserId)
            {
                result = true;
                return result;
            }

            return result;
        }

        public async Task<HouseDetailsDto> HouseDetailsById(int id)
        {
            var house = await this.repo
                .AllReadonly<House>()
                .Where(h => h.IsActive)
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsDto()
                {
                    Id = h.Id,
                    Address = h.Address,
                    Category = h.Category.Name,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                    PricePerMonth = h.PricePerMonth,
                    IsRented = h.RenterId != null,
                    Agent = new DTOs.Agent.AgentServiceModel()
                    {
                        Email = h.Agent.User.Email,
                        PhoneNumber = h.Agent.PhoneNumber
                    }
                })
                .FirstAsync();

            return house;
        }

        public async Task<bool> IsRented(int houseId)
        {
            House? house = await this.repo
                .GetByIdAsync<House>(houseId);

            return house?.RenterId != null;
        }

        public async Task<bool> IsRentedByUserWithId(string userId, int houseId)
        {
            bool result = false;

            var house = await this.repo
                .AllReadonly<House>()
                .Where(h => h.IsActive)
                .Where(h => h.Id == houseId)
                .FirstOrDefaultAsync();

            if (house != null && house.RenterId == userId)
            {
                result = true;
                return result;
            }

            return result;
        }

        public async Task Leave(int houseId)
        {
            var house = await this.repo
                .GetByIdAsync<House>(houseId);

            this.guard.AgainstNull(house, "House can not be found");

            house.RenterId = null;

            await this.repo.SaveChangesAsync();
        }

        public async Task Rent(int houseId, string userId)
        {
            var house = await this.repo
                .GetByIdAsync<House>(houseId);

            //in case house is null:
            this.guard.AgainstNull(house, "House can not be found");

            if (house != null && house.RenterId != null)
            {
                throw new ArgumentException("House is already rented");
            }

            if (house != null && house.RenterId == null)
            {
                house.RenterId = userId;
                await this.repo.SaveChangesAsync();
            }
        }
    }
}
