using AcademiasAPI.Domain.Dto.Academia;
using AcademiasAPI.Domain.Models;
using AutoMapper;

namespace AcademiasAPI.Infrastructure.CrossCutting.AutoMapper;

public class AcademiaProfile : Profile
{
    public AcademiaProfile()
    {
        CreateMap<Academia, ReadAcademiaDto>();
        CreateMap<CreateAcademiaDto, Academia>();
    }
}