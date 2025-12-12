using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Infrastructure.Repositories.Interfaces;

public interface IExercicioRep : IBaseRep<Exercicio>
{
    public Exercicio? GetById(Guid id, bool includeMaquinas);
    public void SetVideo(Guid id, string video);
}