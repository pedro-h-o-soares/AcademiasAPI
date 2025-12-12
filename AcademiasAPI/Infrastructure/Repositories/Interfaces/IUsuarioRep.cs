using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Infrastructure.Repositories.Interfaces;

public interface IUsuarioRep : IBaseRep<Usuario>
{
    public Usuario? GetByEmail(string email);
    public Usuario? GetByEmailESenha(string email, string senha);
    public Usuario? GetByIdIgnoreGlobalFilter(Guid id);
}