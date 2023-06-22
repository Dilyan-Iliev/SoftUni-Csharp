namespace Microsoft.Extensions.DependencyInjection
{
    using HouseRentingSystem.Core.Data;
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.Exceptions;
    using HouseRentingSystem.Services.Interfaces;
    using HouseRentingSystem.Services.Services;
    using Microsoft.EntityFrameworkCore;

    public static class HouseRentingApiServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }

        public static IServiceCollection AddHouseRentingDbContext(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString(connectionString)));

            return services;
        }
    }
}
