using AutoMapper;
using ProductShop.DTOs.Export.Products;
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
        }
    }
}
