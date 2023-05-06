namespace Library.Common
{
    public static class DataConstants
    {
        public static class ApplicationUserConstants
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;
        }

        public static class BookConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;

            public const decimal MinRating = 0.00m;
            public const decimal MaxRating = 10.00m;
        }

        public static class CategoryConstants
        {
            public const int NameMinlength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
