namespace TaskboardApp.Common
{
    public static class DataConstants
    {
        public static class AccountConstants
        {
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 20;

            public const int EmailMinLength = 6;
            public const int EmailMaxLength = 50;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 20;
        }

        public static class TaskConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public static class BoardConstants
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }
    }
}
