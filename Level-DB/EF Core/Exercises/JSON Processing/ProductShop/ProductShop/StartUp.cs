namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.DTOs.Export.Products;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class StartUp
    {
        private static IMapper mapper;
        public static void Main()
        {
            //*ConfigMapper(); //init autoMapper

            var dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();
            //Console.WriteLine("DB created successfuly");

            //For task 1 to 4 use this
            //string jsonFile = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(dbContext, jsonFile));

            //For task 5 to 8 use this
            string result = GetProductsInRange(dbContext);
            //File.WriteAllText("../../../Results/productsInRange.json", result);
        }

        //Task.01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            UserModel[] userModels = JsonConvert.DeserializeObject<UserModel[]>(inputJson);

            List<User> users = mapper.Map<ICollection<User>>(userModels)
                .ToList();

            context.Users
                .AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Task.02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ProductModel[] productModels = JsonConvert.DeserializeObject<ProductModel[]>(inputJson);

            List<Product> products = mapper.Map<ICollection<Product>>(productModels)
                .ToList();

            context.Products
                .AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Task.03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ConfigMapper();

            CategoryModel[] categoryModels = JsonConvert.DeserializeObject<CategoryModel[]>(inputJson);

            List<Category> categories = mapper.Map<ICollection<Category>>(categoryModels)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories
                .AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Task.04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ConfigMapper();
            CategoryProductModel[] categoryProductModels =
                JsonConvert.DeserializeObject<CategoryProductModel[]>(inputJson);

            List<CategoryProduct> categoryProducts =
                mapper.Map<ICollection<CategoryProduct>>(categoryProductModels)
                .ToList();

            context.CategoriesProducts
                .AddRange(categoryProducts);

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Task.05
        public static string GetProductsInRange(ProductShopContext context)
        {
            ConfigMapper();

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ProductsInRangeModel>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }

        private static void ConfigMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(config);
        }
    }
}