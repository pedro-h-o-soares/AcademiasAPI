using System.ComponentModel.DataAnnotations;

namespace AcademiasAPI.Domain.Dto.Academia;

public class CreateAcademiaDto : CreateBaseDto
{
    [Required(ErrorMessage = "O nome da academia é obrigatório")]
    [MaxLength(40, ErrorMessage = "O nome da academia não pode conter mais que 40 caracteres")]
    public string Nome { get; set; }
}