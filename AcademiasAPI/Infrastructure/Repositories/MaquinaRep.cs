using AcademiasAPI.Domain.Models;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademiasAPI.Infrastructure.Repositories;

public class MaquinaRep(AcademiaContext context) 
    : BaseRep<Maquina>(context), 
        IMaquinaRep
{
    public void SetFoto(Guid id, string foto)
    {
        context.Maquinas
            .Where(m => m.Id == id)
            .ExecuteUpdate(s => s.SetProperty(m => m.Foto, foto));
    }
}