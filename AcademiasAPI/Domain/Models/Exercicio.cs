using AcademiasAPI.Domain.Models.Interfaces;

namespace AcademiasAPI.Domain.Models;

public class Exercicio : Base, IAcademiaTenant
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public string? Video { get; set; }
    public ICollection<Maquina>? Maquinas { get; set; }
    public Guid AcademiaId { get; set; }
}