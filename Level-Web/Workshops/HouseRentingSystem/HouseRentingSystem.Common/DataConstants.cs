namespace HouseRentingSystem.Common
{
    public static class DataConstants
    {
        public static class CategoryConstants
        {
            public const int NameMaxLength = 50;
        }

        public static class HouseConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AddressMinLength = 30;
            public const int AddressMaxLength = 150;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const decimal MinPricePerMonth = 0.0m;
            public const decimal MaxPricePerMonth = 2000.0m;
        }

        public static class AgentConstants
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
