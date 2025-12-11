using AcademiasAPI.Domain.Dto.Treino;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Services.Interfaces;

public interface ITreinoService : IBaseService<Treino, ReadTreinoDto, CreateTreinoDto>
{
    
}