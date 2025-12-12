using AcademiasAPI.Domain.Dto.ExercicioSerie;
using AcademiasAPI.Domain.Dto.Serie;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Services.Interfaces;

public interface ISerieService : IBaseService<Serie, ReadSerieDto, CreateSerieDto>
{
    public void CreateExercicio(Guid id, CreateExercicioSerieDto dto);
    public void RemoveExercicio(Guid id, Guid exercicioId);
}