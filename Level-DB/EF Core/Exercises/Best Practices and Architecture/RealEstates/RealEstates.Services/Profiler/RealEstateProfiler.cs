namespace RealEstates.Services.Profiler
{
    using AutoMapper;
    using RealEstates.Services.DTOs;
    using RealEstates.Models;

    public class RealEstateProfiler
        : Profile
    {
        public RealEstateProfiler()
        {
            this.CreateMap<Property, PropertyInfoDto>()
                .ForMember(m => m.DistrictName, mo => mo.MapFrom(x => x.District.Name))
                .ForMember(m => m.PropertyType, mo => mo.MapFrom(x => x.PropertyType.Name))
                .ForMember(m => m.BuildingType, mo => mo.MapFrom(x => x.BuildingType.Name));

            this.CreateMap<District, DistrictInfoDto>()
                .ForMember(m => m.PropertiesCount, mo => mo.MapFrom(x => x.Properties.Count))
                .ForMember(m => m.AveragePricePerSquareMeter, mo => mo.MapFrom(x => x.Properties
                        .Where(p => p.Price.HasValue)
                        .Average(p => p.Price / (decimal)p.Size) ?? 0));

            this.CreateMap<Property, PropertyFullDataDto>()
                .ForMember(m => m.DistrictName, mo => mo.MapFrom(x => x.District.Name))
                .ForMember(m => m.PropertyType, mo => mo.MapFrom(x => x.PropertyType.Name))
                .ForMember(m => m.BuildingType, mo => mo.MapFrom(x => x.BuildingType.Name));
            this.CreateMap<Tag, TagInfoDto>();
        }
    }
}
