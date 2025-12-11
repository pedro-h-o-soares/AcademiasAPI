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
    public virtual IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return Ok(service.Get(paginateRequestDto));
    }

    public virtual IActionResult GetById(Guid id)
    {
        return Ok(service.GetById(id));
    }

    public virtual IActionResult Create([FromBody] TCreateDto dto)
    {
        var created = service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    public virtual IActionResult Update(Guid id, [FromBody] TCreateDto dto)
    {
        service.Update(id, dto);
        return NoContent();
    }

    public virtual IActionResult Delete(Guid id)
    {
        service.Delete(id);
        return NoContent();
    }
}