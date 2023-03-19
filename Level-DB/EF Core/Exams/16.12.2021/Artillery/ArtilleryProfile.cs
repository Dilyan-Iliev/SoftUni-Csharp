namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;

    public class ArtilleryProfile : Profile
    {
        public ArtilleryProfile()
        {
            //Import
            this.CreateMap<CountryInputXmlDto, Country>();
            this.CreateMap<ManufacturerInputXmlDto, Manufacturer>();
            this.CreateMap<ShellInputXmlDto, Shell>();
        }
    }
}