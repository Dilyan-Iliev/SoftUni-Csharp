namespace TaskboardApp.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using TaskboardApp.Services.Contracts;
    using TaskboardApp.Services.Services;

    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IBoardService, BoardService>();

            return services;
        }
    }
}
