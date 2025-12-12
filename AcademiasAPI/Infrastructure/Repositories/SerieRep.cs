using AcademiasAPI.Domain.Models;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademiasAPI.Infrastructure.Repositories;

public class SerieRep(AcademiaContext context) : BaseRep<Serie>(context), ISerieRep
{
    public override ICollection<Serie> GetAll()
    {
        return context.Series
            .OrderBy(s => s.Sequencia)
            .ToList();
    }

    public override Serie? GetById(Guid id)
    {
        return context.Series.Include(s => s.Exercicios.OrderBy(e => e.Sequencia))
            .ThenInclude(e => e.Exercicio)
            .ThenInclude(e => e.Maquinas)
            .FirstOrDefault(s => s.Id == id);
    }

    public void CreateExercicio(Guid serieId, ExercicioSerie exercicio)
    {
        exercicio.SerieId = serieId;
        context.ExerciciosSerie.Add(exercicio);
        
        context.SaveChanges();
    }

    public void RemoveExercicio(Guid exercicioId)
    {
        context.ExerciciosSerie
            .Where(e => e.Id == exercicioId)
            .ExecuteDelete();
    }
}