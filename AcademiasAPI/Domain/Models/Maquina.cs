using AcademiasAPI.Domain.Models.Interfaces;

namespace AcademiasAPI.Domain.Models;

public class Maquina : Base, IAcademiaTenant
{
    public string Nome { get; set; }
    public string? Foto { get; set; }
    public Guid AcademiaId { get; set; }
}