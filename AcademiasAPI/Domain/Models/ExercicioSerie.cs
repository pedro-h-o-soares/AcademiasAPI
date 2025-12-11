using AcademiasAPI.Domain.Models.Interfaces;

namespace AcademiasAPI.Domain.Models;

public class ExercicioSerie : Base
{
    public Guid SerieId { get; set; }
    public Guid ExercicioId { get; set; }
    public int Peso { get; set; }
    public int Repeticoes { get; set; }
    public int Sequencia { get; set; }
    public Exercicio Exercicio { get; set; }
}