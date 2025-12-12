using AcademiasAPI.Domain.Dto.Treino;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.CrossCutting.Authentication;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AutoMapper;

namespace AcademiasAPI.Domain.Services;

public class TreinoService(ITreinoRep rep, IMapper mapper) 
    : BaseService<Treino, ReadTreinoDto, CreateTreinoDto>(rep, mapper), 
        ITreinoService
{
}