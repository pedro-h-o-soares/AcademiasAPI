using AcademiasAPI.Domain.Dto.Treino;
using AcademiasAPI.Domain.Models;
using AutoMapper;

namespace AcademiasAPI.Infrastructure.CrossCutting.AutoMapper;

public class TreinoProfile : Profile
{
    public TreinoProfile()
    {
        CreateMap<Treino, ReadTreinoDto>();
        CreateMap<CreateTreinoDto, Treino>();
    }
}