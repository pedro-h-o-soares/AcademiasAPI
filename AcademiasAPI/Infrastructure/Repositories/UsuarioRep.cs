using AcademiasAPI.Domain.Models;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademiasAPI.Infrastructure.Repositories;

public class UsuarioRep(AcademiaContext context) : BaseRep<Usuario>(context), IUsuarioRep
{
    public Usuario? GetByEmail(string email)
    {
        return context.Usuarios.FirstOrDefault(x => x.Email == email);
    }

    public Usuario? GetByEmailESenha(string email, string senha)
    {
        return context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
    }

    public Usuario? GetByIdIgnoreGlobalFilter(Guid id)
    {
        return context.Usuarios
            .IgnoreQueryFilters()
            .FirstOrDefault(x => x.Id == id);
    }
}