namespace Theatre.Utils
{
    public static class GlobalConstants
    {
        //Theatre
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const sbyte TheatreMinNumberOfHalls = 1;
        public const sbyte TheatreMaxNumberOfHalls = 10;
        public const int TheatreDirectorNameMinLength = 4;
        public const int TheatreDirectorNameMaxLength = 30;

        //Play
        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const double PlayMinRating = 0.00;
        public const double PlayMaxRating = 10.00;
        public const int PlayDescriptionMaxLength = 700;
        public const int PlayScreenWriterNameMinLength = 4;
        public const int PlayScreenWriterNameMaxLength = 30;

        //Cast
        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;
        public const string CastPhoneNumberRegex = @"^\+44-\d{2}-\d{3}-\d{4}$";

        //Ticket
        public const decimal TicketMinPrice = 1.00m;
        public const decimal TicketMaxPrice = 100.00m;
        public const sbyte TicketMinRowNumber = 1;
        public const sbyte TicketMaxRowNumber = 10;
    }
}
