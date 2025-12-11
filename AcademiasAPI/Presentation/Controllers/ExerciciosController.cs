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
    [HttpGet]
    public override IActionResult Get(PaginateRequestDto paginateRequestDto)
    {
        return base.Get(paginateRequestDto);
    }

    [HttpGet("{id}")]
    public override IActionResult GetById(Guid id)
    {
        return base.GetById(id);
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public override IActionResult Create(CreateExercicioDto dto)
    {
        return base.Create(dto);
    }

    [HttpPost("{id}/video")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateVideo(Guid id, [FromForm] IFormFile file)
    {
        await service.UpdateVideoExercicioAsync(id, file);
        return Ok();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    public override IActionResult Update(Guid id, CreateExercicioDto dto)
    {
        return base.Update(id, dto);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public override IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}