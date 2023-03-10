namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class StartUp
    {
        private static IMapper mapper;
        public static void Main()
        {
            ConfigMapper();
            var dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            string jsonFile = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(dbContext, jsonFile));
        }

        //Task.01
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            SupplierModel[] supplierModels = JsonConvert.DeserializeObject<SupplierModel[]>(inputJson);

            Supplier[] suppliers = mapper.Map<ICollection<Supplier>>(supplierModels)
                .ToArray();

            context.Suppliers
                .AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        //Task.02
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            PartModel[] partModels = JsonConvert.DeserializeObject<PartModel[]>(inputJson);

            int[] suppliersIds = context
                .Suppliers
                .AsNoTracking()
                .Select(s => s.Id)
                .ToArray();

            Part[] parts = mapper.Map<ICollection<Part>>(partModels)
                .Where(s => suppliersIds.Contains(s.SupplierId))
                .ToArray();

            context.Parts
                .AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        //Task.03
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            CarModel[] carModels = JsonConvert.DeserializeObject<CarModel[]>(inputJson);

            ICollection<Car> cars = new List<Car>();

            foreach (var carModel in carModels)
            {
                Car car = new Car()
                {
                    Make = carModel.Make,
                    Model = carModel.Model,
                    TravelledDistance = carModel.TravelledDistance
                };

                ICollection<PartCar> partCars = new List<PartCar>();
                foreach (var partId in carModel.PartsId.Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    partCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }

                car.PartsCars = partCars;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Task.04
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            CustomerModel[] customerModels =
                JsonConvert.DeserializeObject<CustomerModel[]>(inputJson);

            ICollection<Customer> customers = mapper.Map<ICollection<Customer>>(customerModels)
                .ToArray();

            context.Customers
                .AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Task.05
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            SaleModel[] saleModels =
                JsonConvert.DeserializeObject<SaleModel[]>(inputJson);

            ICollection<Sale> sales = new List<Sale>();

            foreach (var saleModel in saleModels)
            {
                Sale sale = mapper.Map<Sale>(saleModel);

                sales.Add(sale);
            }

            context.Sales
                .AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        private static void ConfigMapper()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(configuration);
        }
    }
}