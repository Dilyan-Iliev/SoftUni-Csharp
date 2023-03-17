namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchersWithTrucks = context
                .Despatchers
                .ToArray()
                .Where(d => d.Trucks.Any())
                .Select(d => new DespatchersWithTruckOutputXmlModel
                {
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                        .Select(t => new TrucksInfoOutputXmlModel
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType.ToString()
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray(),
                    TrucksCount = d.Trucks.Count
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            XmlRootAttribute root = new XmlRootAttribute("Despatchers");
            XmlSerializer serializer = new XmlSerializer(typeof(DespatchersWithTruckOutputXmlModel[]), root);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using StringWriter sw = new StringWriter(sb);
            serializer.Serialize(sw, despatchersWithTrucks, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsWithTrucks = context
                .Clients
                .ToArray()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new ClientsWithTrucksOutputJsonModel
                {
                    ClientName = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(t => new TruckInfoOutputJsonModel
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            VinNumber = t.Truck.VinNumber,
                            TankCapacity = t.Truck.TankCapacity,
                            CargoCapacity = t.Truck.CargoCapacity,
                            CategoryType = t.Truck.CategoryType.ToString(),
                            MakeType = t.Truck.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.ClientName)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clientsWithTrucks, Formatting.Indented);
        }
    }
}
