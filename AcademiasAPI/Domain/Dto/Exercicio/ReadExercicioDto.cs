using AcademiasAPI.Domain.Dto.Maquina;

namespace AcademiasAPI.Domain.Dto.Exercicio;

public class ReadExercicioDto : ReadBaseDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string? Video { get; set; }
    public ICollection<ReadMaquinaDto>? Maquinas { get; set; }
}