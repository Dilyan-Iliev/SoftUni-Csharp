namespace RealEstates.Services
{
    using RealEstates.Services.DTOs;

    /*
    * в сървисите е функционалността на нашето приложение, 
    * като сървисите се състоят от интерфейс <-> клас ; интерфейс <-> клас
    * в интерфейса се описва какво ще има съответния клас
    */
    public interface IPropertiesService
    {
        void Add(string district, byte floor, byte maxFloor,
            int size, int yardSize, int year, string propertyType,
            string buildingType, int price);

        decimal AveagePricePrerSquareMeter();

        decimal AveagePricePrerSquareMeter(int districtId);

        double AveragePropertySize(int districtId);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);

        IEnumerable<PropertyFullDataDto> GetFullData(int count);
    }
}
