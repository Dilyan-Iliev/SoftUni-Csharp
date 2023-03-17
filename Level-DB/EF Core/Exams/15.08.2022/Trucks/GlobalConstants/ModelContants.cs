namespace Trucks.GlobalConstants
{
    public static class ModelContants
    {
        //Client
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 40;
        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;

        //Despatcher
        public const int DespatcherNameMinLength = 2;
        public const int DespatcherNameMaxLength = 40;

        //Truck
        public const string RegistrationNumberRegex = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const string VinNumberRegex = @"[A-Za-z0-9]{17}";
        public const int TruckMinTankCapacity = 950;
        public const int TruckMaxTankCapacity = 1420;
        public const int TruckMinCargoCapacity = 5000;
        public const int TruckMaxCargoCapacity = 29000;
    }
}
