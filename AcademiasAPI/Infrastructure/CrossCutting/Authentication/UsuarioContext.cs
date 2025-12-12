using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Infrastructure.CrossCutting.Authentication;

public class UsuarioContext
{
    public Guid? AcademiaId { get; set; }
    public Guid? UsuarioId { get; set; }
    public ICollection<Direito> Direitos { get; set; } = [];

    public Guid RequireAcademiaId()
    {
        if (AcademiaId is null || AcademiaId == Guid.Empty)
        {
            throw new InvalidAcademiaIdException();
        }

        return AcademiaId.Value;
    }

    public Guid RequireUsuarioId()
    {
        if (UsuarioId is null || UsuarioId == Guid.Empty)
        {
            throw new CustomUnauthorizedException("ID de usuário inválido");
        }
        
        return UsuarioId.Value;
    }
}