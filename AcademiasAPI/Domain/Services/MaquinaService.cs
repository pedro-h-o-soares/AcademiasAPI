using AcademiasAPI.Domain.Dto.Maquina;
using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AcademiasAPI.Infrastructure.Storage.Interfaces;
using AutoMapper;

namespace AcademiasAPI.Domain.Services;

public class MaquinaService(IMaquinaRep rep, IMapper mapper, IArquivoStorage storage, IConfiguration config) 
    : BaseService<Maquina, ReadMaquinaDto, CreateMaquinaDto>(rep, mapper),
        IMaquinaService
{
    public async Task UpdateFotoMaquinaAsync(Guid id, IFormFile file)
    {
        var maquina = rep.GetById(id);
        if (maquina is null)
        {
            throw new IdNotFoundException("Máquina", id);
        }
        
        var fileName = await storage.SalvarArquivoAsync(file, 1, maquina.Foto);
        rep.SetFoto(id, fileName);
    }
}