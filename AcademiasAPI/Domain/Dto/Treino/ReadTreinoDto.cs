namespace AcademiasAPI.Domain.Dto.Treino;

public class ReadTreinoDto : ReadBaseDto
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public bool Ativo { get; set; }
}