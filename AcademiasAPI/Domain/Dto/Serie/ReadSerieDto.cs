using AcademiasAPI.Domain.Dto.ExercicioSerie;

namespace AcademiasAPI.Domain.Dto.Serie;

public class ReadSerieDto : ReadBaseDto
{
    public string Letra { get; set; }
    public int Sequencia { get; set; }
    public ICollection<ReadExercicioSerieDto> Exercicios { get; set; }
}