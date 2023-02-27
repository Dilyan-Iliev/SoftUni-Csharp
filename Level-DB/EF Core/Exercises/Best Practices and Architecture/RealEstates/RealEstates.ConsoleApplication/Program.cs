namespace RealEstates.ConsoleApplication
{
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using RealEstates.Data;
    using RealEstates.Services;
    using RealEstates.Services.DTOs;

    public class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var db = new AppDbContext();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("3: Add tag");
                Console.WriteLine("4: Bulk tag to properties");
                Console.WriteLine("5: Average price per square meter");
                Console.WriteLine("6: Get properties full info");
                Console.WriteLine("7. EXIT");

                int userOption = int.Parse(Console.ReadLine());

                if (userOption == 1)
                {
                    PropertySearch(db);
                }
                else if (userOption == 2)
                {
                    MostExpensiveDistrict(db);
                }
                else if (userOption == 3)
                {
                    AddTag(db);
                }
                else if (userOption == 4)
                {
                    BulkTagToProperties(db);
                }
                else if (userOption == 5)
                {
                    AveragePricePerSquareMeter(db);
                }
                else if (userOption == 6)
                {
                    GetPropertyFullInfo(db);
                }
                else if (userOption == 7)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Non existing option, please try again!");
                    Console.ReadKey();
                }
            }
        }

        private static void GetPropertyFullInfo(AppDbContext db)
        {
            Console.Write("Select number of properties:");
            int numOfProperties = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(db);
            var result = service.GetFullData(numOfProperties).ToArray();

            var xmlSerializer = new XmlSerializer(typeof(PropertyFullDataDto[]));
            var sb = new StringBuilder();
            var stringWriter = new StringWriter(sb);
            xmlSerializer.Serialize(stringWriter, result);
            Console.WriteLine(stringWriter.ToString().TrimEnd());
        }

        private static void BulkTagToProperties(AppDbContext db)
        {
            Console.WriteLine("Bulk operation started!");

            ITagsService service = new TagsService(db, new PropertiesService(db));
            service.BulkTagToProperties();

            Console.WriteLine("Bulk operation ended successfully!");
        }

        private static void MostExpensiveDistrict(AppDbContext db)
        {
            Console.Write("District count:");
            int count = int.Parse(Console.ReadLine().Trim());

            IDistrictsService service = new DistrictService(db);
            var mostExpensiveDistricts = service.GetMostExpensiveDistricts(count);

            foreach (var district in mostExpensiveDistricts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter:f2} euro/m ({district.PropertiesCount}) properties");
            }
        }

        private static void PropertySearch(AppDbContext db)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine().Trim());
            Console.Write("Max price:");
            int maxPrice = int.Parse(Console.ReadLine().Trim());
            Console.Write("Min size:");
            int minSize = int.Parse(Console.ReadLine().Trim());
            Console.Write("Max size:");
            int maxSize = int.Parse(Console.ReadLine().Trim());

            IPropertiesService service = new PropertiesService(db);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.Size} => {property.Price} euro.");
            }
        }

        private static void AveragePricePerSquareMeter(AppDbContext db)
        {
            IPropertiesService service = new PropertiesService(db);
            service.AveagePricePrerSquareMeter();
        }

        private static void AddTag(AppDbContext db)
        {
            Console.Write("Enter tag type:");
            string tagType = Console.ReadLine().Trim();

            Console.Write("Enter tag importance (optional):");
            bool isParsed = int.TryParse(Console.ReadLine().Trim(), out int tagImportance);


            ITagsService service = new TagsService(db, new PropertiesService(db));

            int? importance = isParsed ? tagImportance : null;

            if (db.Tags.Any(x => x.Name == tagType))
            {
                Console.WriteLine("There is already this tag type!");
                return;
            }

            service.Add(tagType, importance);
        }
    }
}