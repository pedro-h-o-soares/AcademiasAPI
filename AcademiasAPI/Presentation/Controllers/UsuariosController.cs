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
public class UsuariosController(IUsuarioService service) : BaseController<Usuario, ReadUsuarioDto, CreateUsuarioDto>(service)
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
    public override IActionResult Create([FromBody] CreateUsuarioDto createDto)
    {
        return  base.Create(createDto);
    }

    [HttpPut("{id}")]
    public override IActionResult Update(Guid id, CreateUsuarioDto dto)
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