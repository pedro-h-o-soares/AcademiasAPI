using AcademiasAPI.Domain.Dto.Academia;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Services.Interfaces;

public interface IAcademiaService : IBaseService<Academia, ReadAcademiaDto, CreateAcademiaDto>
{
    
}