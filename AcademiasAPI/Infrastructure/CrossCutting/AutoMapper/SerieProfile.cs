using AcademiasAPI.Domain.Dto.Serie;
using AcademiasAPI.Domain.Models;
using AutoMapper;

namespace AcademiasAPI.Infrastructure.CrossCutting.AutoMapper;

public class SerieProfile : Profile
{
    public SerieProfile()
    {
        CreateMap<Serie, ReadSerieDto>();
        CreateMap<CreateSerieDto, Serie>();
    }
}