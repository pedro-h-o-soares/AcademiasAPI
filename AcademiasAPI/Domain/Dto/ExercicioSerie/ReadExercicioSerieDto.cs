using AcademiasAPI.Domain.Dto.Exercicio;

namespace AcademiasAPI.Domain.Dto.ExercicioSerie;

public class ReadExercicioSerieDto : ReadBaseDto
{
    public int Peso { get; set; }
    public int Repeticoes { get; set; }
    public int Sequencia { get; set; }
    public ReadExercicioDto Exercicio { get; set; }
}