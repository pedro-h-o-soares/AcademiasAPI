namespace AcademiasAPI.Domain.Dto.Maquina;

public class ReadMaquinaDto : ReadBaseDto
{
    public string Nome { get; set; }
    public string? Foto { get; set; }
}