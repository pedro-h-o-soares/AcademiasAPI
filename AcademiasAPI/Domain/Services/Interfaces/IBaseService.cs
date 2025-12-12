using AcademiasAPI.Domain.Dto;
using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Domain.Services.Interfaces;

public interface IBaseService<TEntity, TReadDto, TCreateDto>
    where TEntity : Base
    where TReadDto : ReadBaseDto
    where TCreateDto : CreateBaseDto
{
    public PaginateResponseDto<TReadDto> Get(PaginateRequestDto paginateRequestDto);
    public ICollection<TReadDto> GetAll();
    public TReadDto GetById(Guid id);
    public TReadDto Create(TCreateDto createDto);
    public TReadDto Create(TEntity entity);
    public void Update(Guid id, TCreateDto dto);
    public void Delete(Guid id);
}