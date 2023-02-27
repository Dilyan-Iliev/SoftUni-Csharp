namespace RealEstates.Services
{
    using AutoMapper.QueryableExtensions;
    using RealEstates.Data;
    using RealEstates.Services.DTOs;
    using System.Collections.Generic;

    public class DistrictService
            : BaseService, IDistrictsService
    {
        private readonly AppDbContext context;

        public DistrictService(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            return context
                .Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                //.Select(d => new DistrictInfoDto
                //{
                //    Name = d.Name,
                //    PropertiesCount = d.Properties.Count(),
                //    AveragePricePerSquareMeter = d.Properties
                //        .Where(p => p.Price.HasValue)
                //        .Average(p => p.Price / (decimal)p.Size) ?? 0
                //})
                .OrderByDescending(x => x.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();
        }
    }
}
