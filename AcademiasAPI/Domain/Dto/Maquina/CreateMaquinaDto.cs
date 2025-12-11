using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Dto.Maquina;

public class CreateMaquinaDto : CreateBaseDto
{
    [Required(ErrorMessage = "O nome da máquina é obrigatório")]
    [MaxLength(40, ErrorMessage = "O nome da máquina não deve conter mais que 40 caracteres")]
    public string Nome { get; set; }
}