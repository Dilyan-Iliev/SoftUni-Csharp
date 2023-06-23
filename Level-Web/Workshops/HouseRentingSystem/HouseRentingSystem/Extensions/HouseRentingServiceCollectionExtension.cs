namespace Microsoft.Extensions.DependencyInjection
{
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.Exceptions;
    using HouseRentingSystem.Services.Interfaces;
    using HouseRentingSystem.Services.Interfaces.Admin;
    using HouseRentingSystem.Services.Services;
    using HouseRentingSystem.Services.Services.Admin;

    public static class HouseRentingServiceCollectionExtension
    {
        //тук ще изнеса добавянето на сървисите, за да не задръствам Program.cs
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection sc) //така правя extension на IServiceCollection
        {
            sc.AddScoped<IRepository, Repository>();
            sc.AddScoped<IHouseService, HouseService>();
            sc.AddScoped<IAgentService, AgentService>();
            sc.AddScoped<IStatisticsService, StatisticsService>();
            sc.AddScoped<IUserService, UserService>();
            sc.AddScoped<IGuard, Guard>();

            return sc;
        }
    }
}
