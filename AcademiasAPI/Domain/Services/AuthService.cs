using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.CrossCutting.Authentication;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;

namespace AcademiasAPI.Domain.Services;

public class AuthService(UsuarioContext ctx, IUsuarioRep usuarioRep) : IAuthService
{
    public void SetAcademiaUsuarioContext(Guid academiaId)
    {
        ctx.AcademiaId = academiaId;
    }

    public void SetUsuarioContext(Guid usuarioId)
    {
        var usuario = usuarioRep.GetByIdIgnoreGlobalFilter(usuarioId);
        if (usuario is null)
        {
            throw new CustomUnauthorizedException("ID de usuário inválido");
        }
        
        ctx.UsuarioId = usuario.Id;
        ctx.AcademiaId = usuario.AcademiaId;
        ctx.Direitos = usuario.Direitos;
    }
}