using AcademiasAPI.Domain.Dto.Maquina;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Services.Interfaces;

public interface IMaquinaService : IBaseService<Maquina, ReadMaquinaDto, CreateMaquinaDto>
{
    public Task UpdateFotoMaquinaAsync(Guid id, IFormFile file);
}