using AutoMapper;
using ProductShop.DTOs.Export.Categories;
using ProductShop.DTOs.Export.Products;
using ProductShop.DTOs.Export.Users;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //For imports:
            this.CreateMap<UserModel, User>();
            this.CreateMap<ProductModel, Product>();
            this.CreateMap<CategoryModel, Category>();
            this.CreateMap<CategoryProductModel, CategoryProduct>();

            //For exports:
            this.CreateMap<Product, ProductsInRangeModel>()
                    .ForMember(m => m.Seller, opt =>
                        opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));

            //Inner dto
            this.CreateMap<Product, SoldProductsModel>()
                .ForMember(m => m.BuyerFirstName, opt =>
                    opt.MapFrom(src => src.Buyer.FirstName))
                .ForMember(m => m.BuyerLastname, opt =>
                    opt.MapFrom(src => src.Buyer.LastName));
            //Outer dto
            this.CreateMap<User, UserWithSoldProductsModel>()
                .ForMember(m => m.SoldProducts, opt =>
                    opt.MapFrom(src => src.ProductsSold
                        .Where(ps => ps.BuyerId.HasValue)));

            this.CreateMap<Category, CategoryByProductCountModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(src => src.Name))
                .ForMember(m => m.ProductsCount, opt => opt.MapFrom(src => src.CategoriesProducts.Count))
                .ForMember(m => m.AveragePrice, opt => opt.MapFrom(src => src.CategoriesProducts.Average(p => p.Product.Price).ToString("f2")))
                .ForMember(m => m.TotalRevenue, opt => opt.MapFrom(src => src.CategoriesProducts.Sum(p => p.Product.Price).ToString("f2")));
        }
    }
}
