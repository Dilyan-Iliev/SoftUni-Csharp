namespace Microsoft.Extensions.DependencyInjection
{
    using AspNetCoreHero.ToastNotification;
    using ForumApp.Filters;
    using ForumApp.Infrastructure.Data.Common;
    using ForumApp.Services.Contracts;
    using ForumApp.Services.Services;

    public static class ForumAppServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<PageVisitCountFilter>();
            services.AddNotyf(cfg =>
            {
                cfg.DurationInSeconds = 5;
                cfg.IsDismissable = true;
                cfg.Position = NotyfPosition.TopCenter;
            });

            return services;
        }
    }
}
