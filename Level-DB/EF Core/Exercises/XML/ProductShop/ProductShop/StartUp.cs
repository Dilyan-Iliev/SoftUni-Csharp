namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using System.Xml.Serialization;

    public class StartUp
    {
        private static IMapper mapper;

        public static void Main()
        {
            //ConfigMapper();

            var dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            string xmlFile = File.ReadAllText("../../../Datasets/categories-products.xml");
            Console.WriteLine(ImportCategoryProducts(dbContext, xmlFile));
        }

        //Task.01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //XmlRootAttribute root = new XmlRootAttribute("Users");
            //var serializer = new XmlSerializer(typeof(UserDto[]), root);

            //using StringReader sr = new StringReader(inputXml);
            //UserDto[] userDtos = (UserDto[])serializer.Deserialize(sr);

            UserDto[] userDtos = Deserializer<UserDto>("Users", inputXml);

            ICollection<User> users = userDtos
                .Select(ud => new User()
                {
                    FirstName = ud.FirstName,
                    LastName = ud.LastName,
                    Age = ud.Age,
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Task.02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            ProductDto[] productDtos = Deserializer<ProductDto>("Products", inputXml);

            ICollection<Product> products = productDtos
                .Select(pd => new Product()
                {
                    Name = pd.Name,
                    Price = pd.Price,
                    SellerId = pd.SellerId,
                    BuyerId = pd.BuyerId ?? null
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Task.03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            CategoryDto[] categoryDtos = Deserializer<CategoryDto>("Categories", inputXml);

            ICollection<Category> categories = categoryDtos
                .Where(cd => cd.Name != null)
                .Select(cd => new Category()
                {
                    Name = cd.Name
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Task.04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            CategoryProductDto[] cpDtos = Deserializer<CategoryProductDto>("CategoryProducts", inputXml);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var cpDto in cpDtos)
            {
                if (context.Categories.Any(c => c.Id == cpDto.CategoryId)
                    && context.Products.Any(p => p.Id == cpDto.ProductId))
                {
                    var categoryProduct = new CategoryProduct()
                    {
                        CategoryId = cpDto.CategoryId,
                        ProductId = cpDto.ProductId,
                    };

                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }


        private static T[] Deserializer<T>(string xmlRootAttributeName, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(xmlRootAttributeName);

            XmlSerializer serializer = new XmlSerializer(typeof(T[]), root);

            using StringReader reader = new StringReader(inputXml);
            T[] dtos = (T[])serializer.Deserialize(reader);

            return dtos;
        }

        private static void ConfigMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());

            mapper = new Mapper(config);
        }
    }
}