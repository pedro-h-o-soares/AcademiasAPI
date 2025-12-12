using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Dto.Usuario;

public class ReadUsuarioDto : ReadBaseDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public ICollection<Direito> Direitos { get; set; }
}