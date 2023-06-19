namespace HouseRentingSystem.Services.Exceptions
{
    public class HouseRentingExeption
        : ApplicationException
    {
        public HouseRentingExeption()
        {
        }

        public HouseRentingExeption(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}
