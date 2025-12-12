using AcademiasAPI.Domain.Dto.Maquina;
using AcademiasAPI.Domain.Dto.Pagination;
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
    /// <summary>
    /// Searches a list of machines
    /// </summary>
    /// <param name="paginateRequestDto">Pagination parameters</param>
    /// <returns>A pginated list of machines</returns>
    [HttpGet]
    public new IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return base.Get(paginateRequestDto);
    }

    /// <summary>
    /// Search for a specific machine
    /// </summary>
    /// <param name="id">ID of desired machine</param>
    /// <returns>The desired machine if exists, else 404</returns>
    [HttpGet("{id}")]
    public new IActionResult GetById(Guid id)
    {
        return base.GetById(id);
    }

    /// <summary>
    /// Creates a new machine
    /// </summary>
    /// <param name="createDto">The new machine to be created</param>
    /// <returns>The created machine</returns>
    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Create([FromBody] CreateMaquinaDto createDto)
    {
        return base.Create(createDto);
    }

    /// <summary>
    /// Update the photo of a machine
    /// </summary>
    /// <param name="id">ID of the desired machine</param>
    /// <param name="file">The new photo</param>
    /// <returns></returns>
    [HttpPut("{id}/foto")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UploadFoto(Guid id, IFormFile file)
    {
        await service.UpdateFotoMaquinaAsync(id, file);
        return NoContent();
    }

    /// <summary>
    /// Update a machine
    /// </summary>
    /// <param name="id">ID of the desired machine</param>
    /// <param name="dto">The updated machine</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Update(Guid id, CreateMaquinaDto dto)
    {
        return base.Update(id, dto);
    }

    /// <summary>
    /// Delete a machine
    /// </summary>
    /// <param name="id">ID of the machine to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}