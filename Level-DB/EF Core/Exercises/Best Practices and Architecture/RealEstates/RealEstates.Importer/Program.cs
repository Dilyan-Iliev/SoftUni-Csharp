namespace RealEstates.Importer
{
    using RealEstates.Data;
    using RealEstates.Services;
    using System.Text.Json;

    public class Program
    {
        static void Main()
        {
            ImportData("imot.bg-houses-Sofia-raw-data-2021-03-18.json"); 
            ImportData("imot.bg-raw-data-2021-03-18.json");
        }

        public static void ImportData(string jsonFile)
        {
            var dbContext = new AppDbContext();
            IPropertiesService service = new PropertiesService(dbContext);

            var properties =
                JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(File.ReadAllText(jsonFile));

            foreach (var jsonProp in properties)
            {
                service.Add(jsonProp.District, jsonProp.Floor, jsonProp.TotalFloors, jsonProp.Size,
                    jsonProp.YardSize, jsonProp.Year, jsonProp.Type, jsonProp.BuildingType, jsonProp.Price);
                Console.Write('.');
            }
        }
    }
}