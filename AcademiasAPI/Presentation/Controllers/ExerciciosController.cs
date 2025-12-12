using AcademiasAPI.Domain.Dto.Exercicio;
using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiasAPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/exercicios")]
[Authorize]
public class ExerciciosController(IExercicioService service) : BaseController<Exercicio, ReadExercicioDto, CreateExercicioDto>(service)
{
    /// <summary>
    /// Searches a list of exercises
    /// </summary>
    /// <param name="paginateRequestDto">Pagination parameters</param>
    /// <returns>A pginated list of exercises</returns>
    [HttpGet]
    public new IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return base.Get(paginateRequestDto);
    }
    
    /// <summary>
    /// Search for a specific exercise
    /// </summary>
    /// <param name="id">ID of desired exercise</param>
    /// <returns>The desired exercise if exists, else 404</returns>
    [HttpGet("{id}")]
    public new IActionResult GetById(Guid id)
    {
        return base.GetById(id);
    }

    /// <summary>
    /// Creates a new exercise
    /// </summary>
    /// <param name="dto">The new exercise to be created</param>
    /// <returns>The created exercise</returns>
    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Create(CreateExercicioDto dto)
    {
        return base.Create(dto);
    }

    /// <summary>
    /// Update the video of an exercise
    /// </summary>
    /// <param name="id">ID of the desired exercise</param>
    /// <param name="file">The new video</param>
    /// <returns></returns>
    [HttpPut("{id}/video")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateVideo(Guid id, IFormFile file)
    {
        await service.UpdateVideoExercicioAsync(id, file);
        return NoContent();
    }

    /// <summary>
    /// Update a exercise
    /// </summary>
    /// <param name="id">ID of the desired exercise</param>
    /// <param name="dto">The updated exercise</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Update(Guid id, CreateExercicioDto dto)
    {
        return base.Update(id, dto);
    }

    /// <summary>
    /// Delete a exercise
    /// </summary>
    /// <param name="id">ID of the exercise to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}