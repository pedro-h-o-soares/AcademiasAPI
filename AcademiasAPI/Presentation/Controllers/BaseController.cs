using AcademiasAPI.Domain.Dto;
using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Dto.Serie;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademiasAPI.Presentation.Controllers;

public class BaseController<TEntity, TReadDto, TCreateDto>(IBaseService<TEntity, TReadDto, TCreateDto> service) 
    : ControllerBase
where TEntity : Base
where TReadDto : ReadBaseDto
where TCreateDto : CreateBaseDto
{
    protected IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return Ok(service.Get(paginateRequestDto));
    }

    protected IActionResult GetById(Guid id)
    {
        return Ok(service.GetById(id));
    }

    protected IActionResult Create(TCreateDto dto)
    {
        var created = service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    protected IActionResult Update(Guid id, TCreateDto dto)
    {
        service.Update(id, dto);
        return NoContent();
    }

    protected IActionResult Delete(Guid id)
    {
        service.Delete(id);
        return NoContent();
    }
}