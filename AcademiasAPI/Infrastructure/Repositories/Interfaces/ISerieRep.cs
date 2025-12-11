using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Infrastructure.Repositories.Interfaces;

public interface ISerieRep : IBaseRep<Serie>
{
    public void CreateExercicio(Guid serieId, ExercicioSerie exercicio);
    public void RemoveExercicio(Guid exercicioId);
}