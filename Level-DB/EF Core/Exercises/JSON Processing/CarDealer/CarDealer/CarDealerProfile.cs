using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //For imports:
            this.CreateMap<SupplierModel, Supplier>();
            this.CreateMap<PartModel, Part>();
            this.CreateMap<CarModel, Car>();
            this.CreateMap<CustomerModel, Customer>();
            this.CreateMap<SaleModel, Sale>();
        }
    }
}
