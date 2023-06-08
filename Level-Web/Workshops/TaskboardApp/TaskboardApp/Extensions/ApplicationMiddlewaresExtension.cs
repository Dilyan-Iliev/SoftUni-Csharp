namespace TaskboardApp.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationMiddlewaresExtension
    {
        public static IApplicationBuilder AddMidlewares(this IApplicationBuilder app)
        {
            app.UseStatusCodePagesWithRedirects("/Home/Error?error={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
