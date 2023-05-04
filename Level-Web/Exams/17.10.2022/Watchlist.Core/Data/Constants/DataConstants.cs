namespace Watchlist.Core.Data.Constants
{
    public static class DataConstants
    {
        public static class UserConstants
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }

        public static class MovieConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int DirectorMinLength = 5;
            public const int DirectorMaxLength = 50;

            public const decimal MinRating = 0.00m;
            public const decimal MaxRating = 10.00m;
        }

        public static class GenreConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
