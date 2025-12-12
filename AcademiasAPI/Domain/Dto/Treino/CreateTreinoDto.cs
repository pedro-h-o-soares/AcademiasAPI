using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Dto.Treino;

public class CreateTreinoDto : CreateBaseDto
{
    [Required(ErrorMessage = "O campo [nome] é obrigatório")]
    [MaxLength(40, ErrorMessage = "O campo [nome] não deve conter mais que 40 caracteres")]
    public string Nome { get; set; }
    [MaxLength(255, ErrorMessage = "O campo [nome] não deve conter mais que 255 caracteres")]
    public string? Descricao { get; set; }
    public bool Ativo { get; set; } = true;
}