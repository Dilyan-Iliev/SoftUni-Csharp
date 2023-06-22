namespace HouseRentingSystem.Services.Extensions
{
    using HouseRentingSystem.Services.Interfaces;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class ModelExtensions
    {
        public static string GetInformation(this IHouseModel house)
        {
            var sb = new StringBuilder();

            sb.Append(house.Title
                .Replace(" ", "-"));

            sb.Append("-");
            sb.Append(GetAddress(house.Address));

            return sb.ToString();
        }

        private static string GetAddress(string address)
        {
            string result =
                string.Join(" ", address.Split(" ", StringSplitOptions.RemoveEmptyEntries).Take(3));

            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
