using AcademiasAPI.Domain.Models.Interfaces;

namespace AcademiasAPI.Domain.Models;

public class Usuario : Base, IAcademiaTenant
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public Guid AcademiaId { get; set; }
    public ICollection<Direito> Direitos { get; set; }
}