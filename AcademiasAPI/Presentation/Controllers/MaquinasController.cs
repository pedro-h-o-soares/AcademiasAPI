using AcademiasAPI.Domain.Dto.Maquina;
using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Dto.Usuario;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiasAPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class MaquinasController(IMaquinaService service) : BaseController<Maquina, ReadMaquinaDto, CreateMaquinaDto>(service)
{
    [HttpGet]
    public new IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return base.Get(paginateRequestDto);
    }

    [HttpGet("{id}")]
    public new IActionResult GetById(Guid id)
    {
        return base.GetById(id);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Create([FromBody] CreateMaquinaDto createDto)
    {
        return base.Create(createDto);
    }

    [HttpPost("{id}/foto")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UploadFoto(Guid id, IFormFile file)
    {
        await service.UpdateFotoMaquinaAsync(id, file);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Update(Guid id, CreateMaquinaDto dto)
    {
        return base.Update(id, dto);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}