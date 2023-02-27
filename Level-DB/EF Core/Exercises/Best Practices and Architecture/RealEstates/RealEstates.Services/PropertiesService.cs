namespace RealEstates.Services
{
    using AutoMapper.QueryableExtensions;
    using RealEstates.Data;
    using RealEstates.Models;
    using RealEstates.Services.DTOs;
    using System.Collections.Generic;

    public class PropertiesService
            : BaseService, IPropertiesService
    {
        private readonly AppDbContext context;
        //за да работи всеки един сървис, той има нужда до нашия контекст
        public PropertiesService(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(string district, byte floor, byte maxFloor,
            int size, int yardSize, int year, string propertyType,
            string buildingType, int price)
        {
            var property = new Property()
            {
                Size = size,
                Price = price <= 0 ? null : price,
                YardSize = yardSize <= 0 ? null : yardSize,
                Floor = floor <= 0 || floor > 255 ? null : floor,
                TotalFloors = maxFloor <= 0 || maxFloor >= 255 ? null : maxFloor,
                BuiltYear = year <= 1800 ? null : year,
            };

            var dbDistrict = context
                .Districts
                .FirstOrDefault(d => d.Name == district);

            if (dbDistrict == null)
            {
                dbDistrict = new District() { Name = district };
            }
            property.District = dbDistrict;

            var dbPropertyType = context
                .PropertyTypes
                .FirstOrDefault(p => p.Name == propertyType);

            if (dbPropertyType == null)
            {
                dbPropertyType = new PropertyType() { Name = propertyType };
            }
            property.PropertyType = dbPropertyType;

            var dbBuildingType = context
                .BuildingTypes
                .FirstOrDefault(b => b.Name == buildingType);

            if (dbBuildingType == null)
            {
                dbBuildingType = new BuildingType() { Name = buildingType };
            }
            property.BuildingType = dbBuildingType;

            context.Properties.Add(property);
            context.SaveChanges();
        }

        public decimal AveagePricePrerSquareMeter()
        {
            return context
                .Properties
                .Where(p => p.Price.HasValue)
                .Average(p => p.Price / (decimal)p.Size) ?? 0;
        }

        public double AveragePropertySize(int districtId)
        {
            return context
                .Properties
                .Where(p => p.DistrictId == districtId)
                .Average(p => p.Size);
        }

        public decimal AveagePricePrerSquareMeter(int districtId)
        {
            return context
                .Properties
                .Where(p => p.Price.HasValue && p.DistrictId == districtId)
                .Average(p => p.Price / (decimal)p.Size) ?? 0;
        }

        public IEnumerable<PropertyFullDataDto> GetFullData(int count)
        {
            return context
                .Properties
                .Where(p => p.Floor.HasValue 
                && p.Floor.Value > 1 
                && p.Floor.Value <= 8
                && p.BuiltYear.HasValue
                && p.BuiltYear.Value > 2015)
                .ProjectTo<PropertyFullDataDto>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(p => p.Price)
                .ThenBy(p => p.Size)
                .ThenBy(p => p.BuiltYear)
                .Take(count)
                .ToList();
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        {
            return context
                .Properties
                .Where(p => (p.Price >= minPrice && p.Price <= maxPrice)
                && (p.Size >= minSize && p.Size <= minSize))
                .ProjectTo<PropertyInfoDto>(this.Mapper.ConfigurationProvider) //this is with automapper
                //.Select(p => new PropertyInfoDto()
                //{
                //    BuildingType = p.BuildingType.Name,
                //    DistrictName = p.District.Name,
                //    PropertyType = p.PropertyType.Name,
                //    Price = p.Price ?? 0, //т.е. ако не е цяло число, а е null да влезе 0
                //    Size = p.Size,
                //})
                .ToList();
        }
    }
}
