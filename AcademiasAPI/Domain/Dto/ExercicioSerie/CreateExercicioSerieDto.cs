using System.ComponentModel.DataAnnotations;
using AcademiasAPI.Domain.Attributes;

namespace AcademiasAPI.Domain.Dto.ExercicioSerie;

public class CreateExercicioSerieDto : CreateBaseDto
{
    [NotEmpty(ErrorMessage = "O campo [exercicio_id] é obrigatório")]
    public Guid ExercicioId { get; set; }
    [Range(1, Int32.MaxValue, ErrorMessage = "O campo [peso] deve ser maior que 0")]
    public int Peso { get; set; }
    [Range(1, Int32.MaxValue, ErrorMessage = "O campo [repetições] deve ser maior que 0")]
    public int Repeticoes { get; set; }
    [Range(1, Int32.MaxValue, ErrorMessage = "O campo [sequencia] deve ser maior que 0")]
    public int Sequencia { get; set; }
}