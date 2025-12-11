using AcademiasAPI.Domain.Models.Interfaces;

namespace AcademiasAPI.Domain.Models;

public class Treino : Base, IUsuarioTenant
{
    public Guid UsuarioId { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Ativo { get; set; }
}