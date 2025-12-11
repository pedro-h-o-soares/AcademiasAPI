using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Infrastructure.Repositories.Interfaces;

public interface IMaquinaRep : IBaseRep<Maquina>
{
    public void SetFoto(Guid id, string foto);
}