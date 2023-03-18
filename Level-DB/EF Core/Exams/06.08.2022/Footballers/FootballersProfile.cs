namespace Footballers
{
    using AutoMapper;
    using Footballers.Data.Models;
    using Footballers.DataProcessor.ExportDto;
    using Footballers.DataProcessor.ImportDto;

    public class FootballersProfile : Profile
    {
        public FootballersProfile()
        {
            this.CreateMap<Footballer, CoachFootballersOutputXmlModel>()
                .ForMember(dto => dto.Name, m => m.MapFrom(f => f.Name))
                .ForMember(dto => dto.Position, m => m.MapFrom(f => f.PositionType.ToString()));
            this.CreateMap<Coach, CoachOutputXmlModel>()
                .ForMember(dto => dto.Name, m => m.MapFrom(c => c.Name))
                .ForMember(dto => dto.FootballersCount, m => m.MapFrom(c => c.Footballers.Count))
                .ForMember(dto => dto.Footballers, m => m.MapFrom(c => c.Footballers.ToArray().OrderBy(f => f.Name).ToArray()));
        }
    }
}
