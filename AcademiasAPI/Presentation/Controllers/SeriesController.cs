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
    public new IActionResult Create(CreateSerieDto dto)
    {
        return base.Create(dto);
    }

    [HttpPut("{id}")]
    public new IActionResult Update(Guid id, CreateSerieDto dto)
    {
        return base.Update(id, dto);
    }

    [HttpPatch("{id}/exercicios")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult CreateExercicio(Guid id, CreateExercicioSerieDto dto)
    {
        service.CreateExercicio(id, dto);
        return Ok();
    }

    [HttpPatch("{id}/exercicios/{exercicioId}/remove")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult DeleteExercicio(Guid id, Guid exercicioId)
    {
        service.RemoveExercicio(id, exercicioId);
        return Ok();
    }

    [HttpDelete("{id}")]
    public new IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}