namespace RealEstates.Services
{
    using RealEstates.Services.DTOs;

    public interface IDistrictsService
    {
        //връща най-скъпте n на брой квартали
        IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count); 
    }
}
