using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AcademiasAPI.Domain.Dto.Auth;
using AcademiasAPI.Domain.Dto.Usuario;
using AcademiasAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AcademiasAPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[AllowAnonymous]
public class AuthController(IUsuarioService usuarioService, IConfiguration configuration) : ControllerBase
{
    /// <summary>
    /// Authenticates user in the application
    /// </summary>
    /// <param name="dto">User credentials</param>
    /// <returns>The user information and the auth cookie</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var usuario = usuarioService.AutenticaUsuario(dto);
        var claims = GetClaims(usuario);
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity));
        return Ok(usuario);
    }

    private ICollection<Claim> GetClaims(ReadUsuarioDto usuario)
    {
        var claims = new List<Claim>()
        {
            new (ClaimTypes.GivenName, usuario.Nome),
            new (ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        };

        foreach (var role in usuario.Direitos)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.NomeNormalizado));
        }

        return claims;
    }
    
    private string GerarToken(ReadUsuarioDto usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = configuration.GetValue<string>("Auth:Jwt:Key")!;
        
        var byteKey = Encoding.ASCII.GetBytes(key);
        var claims = new List<Claim>()
        {
            new (ClaimTypes.GivenName, usuario.Nome),
            new (ClaimTypes.NameIdentifier, usuario.Id.ToString()),
        };

        claims.AddRange(usuario.Direitos.Select(direito => new Claim(ClaimTypes.Role, direito.NomeNormalizado)));
        
        var expirationHours = configuration.GetValue<int>("Auth:Jwt:ExpirationHours");
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(expirationHours),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}