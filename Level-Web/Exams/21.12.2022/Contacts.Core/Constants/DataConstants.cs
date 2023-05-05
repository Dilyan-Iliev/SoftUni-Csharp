namespace Contacts.Core.Constants
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

        public static class ContactConstants
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 5;
            public const int LastNameMaxLength = 50;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 50;

            public const int PhoneMinLength = 10;
            public const int PhoneMaxLength = 13;
            public const string PhonNumberRegex = @"^(\+359|0)[ -]?\d{3}[ -]?\d{2}[ -]?\d{2}[ -]?\d{2}$";

            public const string WebsiteRegex = @"^www\.[A-Za-z\d-]+\.bg$";
        }
    }
}
