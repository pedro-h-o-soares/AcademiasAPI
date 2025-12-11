using AcademiasAPI.Domain.Dto.Usuario;

namespace AcademiasAPI.Domain.Dto.Auth;

public class TokenDto
{
    public string Token { get; set; }
    public ReadUsuarioDto Usuario { get; set; }
    public double ExpiresIn { get; set; }
}