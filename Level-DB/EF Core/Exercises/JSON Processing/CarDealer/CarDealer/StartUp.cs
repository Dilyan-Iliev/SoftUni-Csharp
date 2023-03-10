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
            var dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            string jsonFile = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(dbContext, jsonFile));
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

        //public static string ImportCars(CarDealerContext context, string inputJson)
        //{

        //}

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