using AcademiasAPI.Domain.Models.Interfaces;

namespace AcademiasAPI.Domain.Models;

public class Serie : Base, IUsuarioTenant
{
    public string Letra { get; set; }
    public int Sequencia { get; set; }
    public Guid TreinoId { get; set; }
    public Guid UsuarioId { get; set; }
    public ICollection<ExercicioSerie> Exercicios { get; set; }
}