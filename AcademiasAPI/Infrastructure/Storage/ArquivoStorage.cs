using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Infrastructure.Storage.Interfaces;

namespace AcademiasAPI.Infrastructure.Storage;

public class ArquivoStorage : IArquivoStorage
{
    private readonly Dictionary<int, string[]> ValidExtensions;
    private readonly string BasePath;
    
    public ArquivoStorage(IConfiguration config)
    {
        var storageUrl = config.GetValue<string>("FileStorage:StorageUrl");
        var basePath = config.GetValue<string>("FileStorage:Path") ?? throw new Exception("FileStorage:Path not found");

        BasePath = basePath;
        if (storageUrl is not null)
        {
            BasePath = Path.Combine(storageUrl, BasePath);
        }
        
        ValidExtensions = config.GetSection("FileStorage:ValidExtensions").Get<Dictionary<int, string[]>>() 
                          ?? throw new Exception("FileStorage:ValidExtensions is null");
    }
    
    public async Task<string> SalvarArquivoAsync(IFormFile formFile, int tipo)
    {
        if (formFile.Length == 0)
        {
            throw new EmptyFileException();
        }

        var extension = Path.GetExtension(formFile.FileName);
        if (!ValidExtensions[tipo].Contains(extension))
        {
            throw new InvalidFileExtensionException();
        }

        if (!Directory.Exists(BasePath))
        {
            Directory.CreateDirectory(BasePath);
        }

        var nomeArquivo = Path.ChangeExtension(Path.GetRandomFileName(), extension);
        var arquivoPath = Path.Combine(BasePath, nomeArquivo);
        
        using (var steam = File.Create(arquivoPath))
        {
            await formFile.CopyToAsync(steam);
        }
        
        return nomeArquivo;
    }

    public Task<string> SalvarArquivoAsync(IFormFile formFile, int tipo, string? oldFile)
    {
        var fileName = SalvarArquivoAsync(formFile, tipo);

        if (oldFile is null)
        {
            return fileName;
        }
        
        var path = Path.Combine(BasePath, oldFile);
        
        File.Delete(path);

        return fileName;
    }

    public Task<byte[]> BuscarArquivoAsync(string nomeArquivo)
    {
        var arquivoPath = Path.Combine(BasePath, nomeArquivo);
        var arquivo = File.ReadAllBytes(arquivoPath);
        
        return Task.FromResult(arquivo);
    }

    public string BuscarFotoPath(string nomeArquivo)
    {
        return Path.Combine(BasePath, nomeArquivo);
    }
}