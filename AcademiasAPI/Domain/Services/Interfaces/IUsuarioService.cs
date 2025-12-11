using AcademiasAPI.Domain.Dto.Auth;
using AcademiasAPI.Domain.Dto.Usuario;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Services.Interfaces;

public interface IUsuarioService : IBaseService<Usuario, ReadUsuarioDto, CreateUsuarioDto>
{
    public ReadUsuarioDto AutenticaUsuario(LoginDto dto);
}