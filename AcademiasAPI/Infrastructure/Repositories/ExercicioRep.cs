using AcademiasAPI.Domain.Models;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademiasAPI.Infrastructure.Repositories;

public class ExercicioRep(AcademiaContext context) 
    : BaseRep<Exercicio>(context),
        IExercicioRep
{
    public Exercicio? GetById(Guid id, bool inclideMaquinas)
    {
        if (!inclideMaquinas)
        {
            return GetById(id);
        }

        return context.Set<Exercicio>()
            .Include(e => e.Maquinas)
            .FirstOrDefault(x => x.Id == id);
    }

    public void SetVideo(Guid id, string video)
    {
        context.Exercicios
            .Where(e => e.Id == id)
            .ExecuteUpdate(p => p.SetProperty(ex => ex.Video, video));
    }
}