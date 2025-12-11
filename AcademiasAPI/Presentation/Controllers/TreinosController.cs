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
    public override IActionResult Create(CreateTreinoDto dto)
    {
        return base.Create(dto);
    }

    [HttpPut("{id}")]
    public override IActionResult Update(Guid id, CreateTreinoDto dto)
    {
        return base.Update(id, dto);
    }

    [HttpDelete("{id}")]
    public override IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}