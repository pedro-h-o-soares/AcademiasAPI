using AcademiasAPI.Domain.Dto.Academia;
using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcademiasAPI.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "ADMIN")]
public class AcademiasController(IAcademiaService service) : BaseController<Academia, ReadAcademiaDto, CreateAcademiaDto>(service)
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
}