namespace Microsoft.Extensions.DependencyInjection
{
    using HouseRentingSystem.Core.Data.Repository;
    using HouseRentingSystem.Services.Interfaces;
    using HouseRentingSystem.Services.Services;

    public static class HouseRentingServiceCollectionExtension
    {
        //тук ще изнеса добавянето на сървисите, за да не задръствам Program.cs
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection sc) //така правя extension на IServiceCollection
        {
            sc.AddScoped<IRepository, Repository>();
            sc.AddScoped<IHouseService, HouseService>();
            sc.AddScoped<IAgentService, AgentService>();

            return sc;
        }
    }
}
