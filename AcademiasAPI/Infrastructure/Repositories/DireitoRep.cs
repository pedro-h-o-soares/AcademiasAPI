using AcademiasAPI.Domain.Models;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;

namespace AcademiasAPI.Infrastructure.Repositories;

public class DireitoRep(AcademiaContext context) : BaseRep<Direito>(context), IDireitoRep
{
    public override Direito Create(Direito entity)
    {
        throw new NotImplementedException();
    }
}