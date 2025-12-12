using AcademiasAPI.Domain.Dto.Exercicio;
using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AcademiasAPI.Infrastructure.Storage.Interfaces;
using AutoMapper;

namespace AcademiasAPI.Domain.Services;

public class ExercicioService(IExercicioRep rep, IMapper mapper, IArquivoStorage storage) 
    : BaseService<Exercicio, ReadExercicioDto, CreateExercicioDto>(rep, mapper),
        IExercicioService
{
    public override ReadExercicioDto GetById(Guid id)
    {
        var exercicio = rep.GetById(id, true);
        if (exercicio is null)
        {
            throw new IdNotFoundException("Exercício", id);
        }
        
        return mapper.Map<ReadExercicioDto>(exercicio);
    }
    
    public async Task UpdateVideoExercicioAsync(Guid id, IFormFile file)
    {
        var exercicio = rep.GetById(id);
        if (exercicio is null)
        {
            throw new IdNotFoundException("Exercício", id);
        }
        
        var fileName = await storage.SalvarArquivoAsync(file, 2, exercicio.Video);
        rep.SetVideo(id, fileName);
    }
}