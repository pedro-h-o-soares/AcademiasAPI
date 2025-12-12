using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Dto.Treino;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiasAPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class TreinosController(ITreinoService service) : BaseController<Treino, ReadTreinoDto, CreateTreinoDto>(service)
{
    /// <summary>
    /// Searches a list of trainings
    /// </summary>
    /// <param name="paginateRequestDto">Pagination parameters</param>
    /// <returns>A pginated list of trainings</returns>
    [HttpGet]
    public new IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return base.Get(paginateRequestDto);
    }

    /// <summary>
    /// Search for a specific training
    /// </summary>
    /// <param name="id">ID of desired training</param>
    /// <returns>The desired training if exists, else 404</returns>
    [HttpGet("{id}")]
    public new IActionResult GetById(Guid id)
    {
        return base.GetById(id);
    }

    /// <summary>
    /// Creates a new training
    /// </summary>
    /// <param name="dto">The new training to be created</param>
    /// <returns>The created training</returns>
    [HttpPost]
    public new IActionResult Create(CreateTreinoDto dto)
    {
        return base.Create(dto);
    }

    /// <summary>
    /// Update a training
    /// </summary>
    /// <param name="id">ID of the desired training</param>
    /// <param name="dto">The updated training</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public new IActionResult Update(Guid id, CreateTreinoDto dto)
    {
        return base.Update(id, dto);
    }

    /// <summary>
    /// Delete a training
    /// </summary>
    /// <param name="id">ID of the training to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public new IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}