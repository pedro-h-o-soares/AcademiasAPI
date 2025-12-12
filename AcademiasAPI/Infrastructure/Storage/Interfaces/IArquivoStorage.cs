namespace AcademiasAPI.Infrastructure.Storage.Interfaces;

public interface IArquivoStorage
{
    public Task<string> SalvarArquivoAsync(IFormFile formFile, int tipo);
    public Task<string> SalvarArquivoAsync(IFormFile formFile, int tipo, string? oldFile);
    public Task<byte[]> BuscarArquivoAsync(string fileName);
}