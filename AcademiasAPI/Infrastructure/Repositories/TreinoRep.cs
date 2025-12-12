using AcademiasAPI.Domain.Models;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;

namespace AcademiasAPI.Infrastructure.Repositories;

public class TreinoRep(AcademiaContext context) : BaseRep<Treino>(context), ITreinoRep
{
    
}