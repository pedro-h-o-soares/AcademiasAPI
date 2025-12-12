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
    /// <summary>
    /// Searches a list of users
    /// </summary>
    /// <param name="paginateRequestDto">Pagination parameters</param>
    /// <returns>A pginated list of users</returns>
    [HttpGet]
    public new IActionResult Get([FromQuery] PaginateRequestDto paginateRequestDto)
    {
        return base.Get(paginateRequestDto);
    }

    /// <summary>
    /// Search for a specific user
    /// </summary>
    /// <param name="id">ID of desired user</param>
    /// <returns>The desired user if exists, else 404</returns>
    [HttpGet("{id}")]
    public new IActionResult GetById(Guid id)
    {
        return base.GetById(id);
    }

    /// <summary>
    /// Creates a new user
    /// </summary>
    /// <param name="createDto">The new user to be created</param>
    /// <returns>The created user</returns>
    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Create([FromBody] CreateUsuarioDto createDto)
    {
        return  base.Create(createDto);
    }

    /// <summary>
    /// Update a user
    /// </summary>
    /// <param name="id">ID of the desired user</param>
    /// <param name="dto">The updated user</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public new IActionResult Update(Guid id, CreateUsuarioDto dto)
    {
        return base.Update(id, dto);
    }

    /// <summary>
    /// Delete a user
    /// </summary>
    /// <param name="id">ID of the user to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public new IActionResult Delete(Guid id)
    {
        return base.Delete(id);
    }
}