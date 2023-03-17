namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DespatcherInputXmlModel[]), new XmlRootAttribute("Despatchers"));

            using StringReader stringReader = new StringReader(xmlString);

            var despatcherDtos = (DespatcherInputXmlModel[])xmlSerializer.Deserialize(stringReader);

            List<Despatcher> despatchers = new List<Despatcher>();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string position = despatcherDto.DespatcherPosition;
                bool isPositionInvalid = string.IsNullOrEmpty(position);

                if (isPositionInvalid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher d = new Despatcher()
                {
                    Name = despatcherDto.DespatcherName,
                    Position = position
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck t = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };

                    d.Trucks.Add(t);
                }
                despatchers.Add(d);
                sb.AppendLine(String.Format(SuccessfullyImportedDespatcher, d.Name, d.Trucks.Count));
            }
            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var clientModels = JsonConvert.DeserializeObject<ClientInputJsonModel[]>(jsonString);
            int[] validTruckIds = context.Trucks.Select(t => t.Id).ToArray();
            var clients = new List<Client>();

            foreach (var clientModel in clientModels)
            {
                if (!IsValid(clientModel))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientModel.Trucks.Any(t => t == null))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientModel.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client
                {
                    Name = clientModel.Name,
                    Nationality = clientModel.Nationality,
                    Type = clientModel.Type
                };

                var clientTrucks = new List<ClientTruck>();
                foreach (var truckModeld in clientModel.Trucks.Distinct())
                {
                    if (!validTruckIds.Contains(truckModeld))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck ct = new ClientTruck
                    {
                        Client = client,
                        TruckId = truckModeld
                    };

                    client.ClientsTrucks.Add(ct);
                }

                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
                context.Clients.Add(client);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}