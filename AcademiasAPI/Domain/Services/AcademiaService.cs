using AcademiasAPI.Domain.Dto.Academia;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AutoMapper;

namespace AcademiasAPI.Domain.Services;

public class AcademiaService(IAcademiaRep rep, IMapper mapper)
    : BaseService<Academia, ReadAcademiaDto, CreateAcademiaDto>(rep, mapper), IAcademiaService
{
    
}