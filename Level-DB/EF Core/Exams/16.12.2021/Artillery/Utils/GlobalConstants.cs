namespace Artillery.Utils
{
    public static class GlobalConstants
    {
        //Country
        public const int CountryNameMinLength = 4;
        public const int CountryNameMaxLength = 60;
        public const int CountryArmSizeMinLength = 50000;
        public const int CountryArmSizeMaxLength = 10000000;

        //Manufacturer
        public const int ManufacturerNameMinLength = 4;
        public const int ManufacturerNameMaxLength = 40;
        public const int ManufactuterFoundedMinLength = 10;
        public const int ManufactuterFoundedMaxLength = 100;

        //Shell
        public const double ShellMinWeight = 2.00;
        public const double ShellMaxWeight = 1680.00;
        public const int ShellCaliberMinLength = 4;
        public const int ShellCaliberMaxLength = 30;

        //Gun
        public const int GunMinWeight = 100;
        public const int GunMaxWeight = 1350000;
        public const double GunBarrelMinLength = 2.00;
        public const double GunBarrelMaxLength = 35.00;
        public const int GunMinRange = 1;
        public const int GunMaxRange = 100_000;
    }
}
