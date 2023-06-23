namespace HouseRentingSystem.Services.Services.Admin
{
    using HouseRentingSystem.Core.Data.Entities;
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.DTOs.Admin;
    using HouseRentingSystem.Services.Interfaces.Admin;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService
        : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await this.repo
                .AllReadonly<Agent>()
                .Select(a => new UserServiceModel()
                {
                    Email = a.User.Email,
                    FullName = a.User.FirstName + " " + a.User.LastName,
                    PhoneNumber = a.PhoneNumber
                })
                .ToListAsync();

            string[] agentIds = result.Select(a => a.Id).ToArray();

            var users = await this.repo
                .AllReadonly<ApplicationUser>()
                .Where(u => !agentIds.Contains(u.Id))
                .Select(u => new UserServiceModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                })
                .ToListAsync();

            result.AddRange(users);

            return result;
        }

        public async Task<string> UserFullName(string userId)
        {
            var user = await repo
                .GetByIdAsync<ApplicationUser>(userId);

            return $"{user?.FirstName} {user?.LastName}".Trim();
        }
    }
}
