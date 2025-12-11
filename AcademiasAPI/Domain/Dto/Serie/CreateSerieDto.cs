using System.ComponentModel.DataAnnotations;
using AcademiasAPI.Domain.Attributes;
using AcademiasAPI.Domain.Dto.ExercicioSerie;

namespace AcademiasAPI.Domain.Dto.Serie;

public class CreateSerieDto : CreateBaseDto
{
    [Required(ErrorMessage = "O campo [letra] é obrigatório")]
    [MaxLength(1, ErrorMessage = "O campo [letra] não deve conter mais que 1 caracter")]
    public string Letra { get; set; }
    [Required(ErrorMessage = "O campo [sequencia] é obrigatório")]
    [Range(1, Int32.MaxValue, ErrorMessage = "O campo [sequencia] deve ser maior que 0")]
    public int Sequencia { get; set; }
    [NotEmpty(ErrorMessage = "O campo [treino_id] é obrigatório")]
    public Guid TreinoId { get; set; }
    public ICollection<CreateExercicioSerieDto> Exercicios { get; set; }
}