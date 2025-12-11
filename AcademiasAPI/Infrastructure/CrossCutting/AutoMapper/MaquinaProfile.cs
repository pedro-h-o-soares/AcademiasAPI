using AcademiasAPI.Domain.Dto.Maquina;
using AcademiasAPI.Domain.Models;
using AutoMapper;

namespace AcademiasAPI.Infrastructure.CrossCutting.AutoMapper;

public class MaquinaProfile : Profile
{
    public MaquinaProfile()
    {
        CreateMap<Maquina, ReadMaquinaDto>();
        CreateMap<CreateMaquinaDto, Maquina>();
    }
}