using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Dto.Auth;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Senha { get; set; }
}