namespace Homies.Extensions
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtension
    {
        public static string GetById(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
