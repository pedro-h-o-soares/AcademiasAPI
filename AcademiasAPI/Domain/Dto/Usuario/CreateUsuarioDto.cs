using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Dto.Usuario;

public class CreateUsuarioDto : CreateBaseDto
{
    [Required]
    [MaxLength(40, ErrorMessage = "O nome não deve conter mais que 40 caracteres")]
    public string Nome { get; set; }
    [Required]
    [EmailAddress(ErrorMessage = "O campo email não é um email válido")]
    [MaxLength(50, ErrorMessage = "O email não deve conter mais que 50 caracteres")]
    public string Email { get; set; }
    [Required]
    [MaxLength(20, ErrorMessage = "A senha não deve conter mais que 20 caracteres")]
    public string Senha { get; set; }
    [Required]
    public string ConfirmaSenha { get; set; }
    public ICollection<Guid>? Direitos { get; set; }
}