using AcademiasAPI.Domain.Dto.Exercicio;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Services.Interfaces;

public interface IExercicioService : IBaseService<Exercicio, ReadExercicioDto, CreateExercicioDto>
{
    public Task UpdateVideoExercicioAsync(Guid id, IFormFile file);
}