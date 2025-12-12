using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Dto.Exercicio;

public class CreateExercicioDto : CreateBaseDto
{
    [Required(ErrorMessage = "O nome do exercício é obrigatório")]
    [MaxLength(40, ErrorMessage = "O nome do exercício não deve conter mais que 40 caracteres")]
    public string Nome { get; set; }
    [MaxLength(40, ErrorMessage = "A descrição do exercício não deve conter mais que 255 caracteres")]
    public string Descricao { get; set; }
}