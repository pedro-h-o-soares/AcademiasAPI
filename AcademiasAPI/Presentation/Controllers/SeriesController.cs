using AcademiasAPI.Domain.Dto.ExercicioSerie;
using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Dto.Serie;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiasAPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SeriesController(ISerieService service) 
    : BaseController<Serie, ReadSerieDto, CreateSerieDto>(service)
{
    /// <summary>
    /// Searches a list of series
    /// </summary>
    /// <param name="paginateRequestDto">Pagination parameters</param>
    /// <returns>A pginated list of series</returns>
    [HttpGet]
    public new IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return base.Get(paginateRequestDto);
    }

    /// <summary>
    /// Search for a specific series
    /// </summary>
    /// <param name="id">ID of desired series</param>
    /// <returns>The desired series if exists, else 404</returns>
    [HttpGet("{id}")]
    public new IActionResult GetById(Guid id)
    {
        return base.GetById(id);
    }

    /// <summary>
    /// Creates a new series
    /// </summary>
    /// <param name="dto">The new series to be created</param>
    /// <returns>The created series</returns>
    [HttpPost]
    public new IActionResult Create(CreateSerieDto dto)
    {
        return base.Create(dto);
    }

    /// <summary>
    /// Update a series
    /// </summary>
    /// <param name="id">ID of the desired series</param>
    /// <param name="dto">The updated series</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public new IActionResult Update(Guid id, CreateSerieDto dto)
    {
        return base.Update(id, dto);
    }

    /// <summary>
    /// Includes an exercise into a series 
    /// </summary>
    /// <param name="id">ID of the series</param>
    /// <param name="dto">The exercise to be included</param>
    /// <returns></returns>
    [HttpPost("{id}/exercicios")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult CreateExercicio(Guid id, CreateExercicioSerieDto dto)
    {
        service.CreateExercicio(id, dto);
        return Ok();
    }

    /// <summary>
    /// Removes an exercise from the series
    /// </summary>
    /// <param name="id">ID of the series</param>
    /// <param name="exercicioId">ID of the exercise to be removed</param>
    /// <returns></returns>
    [HttpDelete("{id}/exercicios/{exercicioId}")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult DeleteExercicio(Guid id, Guid exercicioId)
    {
        service.RemoveExercicio(id, exercicioId);
        return Ok();
    }

    /// <summary>
    /// Delete a series
    /// </summary>
    /// <param name="id">ID of the series to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public new IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}