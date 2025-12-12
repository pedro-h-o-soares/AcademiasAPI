using AcademiasAPI.Domain.Dto;
using AcademiasAPI.Domain.Dto.Pagination;
using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AutoMapper;

namespace AcademiasAPI.Domain.Services;

public class BaseService<TEntity, TReadDto, TCreateDto>(IBaseRep<TEntity> rep, IMapper mapper) 
    : IBaseService<TEntity, TReadDto, TCreateDto>
    where TEntity : Base
    where TReadDto : ReadBaseDto
    where TCreateDto : CreateBaseDto
{
    public virtual PaginateResponseDto<TReadDto> Get(PaginateRequestDto paginateRequestDto)
    {
        var results = rep.Get(paginateRequestDto.Page, paginateRequestDto.PageSize, out var total);

        return new PaginateResponseDto<TReadDto>()
        {
            Page = paginateRequestDto.Page,
            PageSize = paginateRequestDto.PageSize,
            Total = total,
            Results = mapper.Map<ICollection<TReadDto>>(results)
        };
    }
    
    public virtual ICollection<TReadDto> GetAll()
    {
        var results = rep.GetAll();
        return mapper.Map<ICollection<TReadDto>>(results);
    }

    public virtual TReadDto GetById(Guid id)
    {
        var result = rep.GetById(id);
        if  (result is null)
            throw new IdNotFoundException(typeof(TEntity).Name, id);
        return mapper.Map<TReadDto>(result);
    }

    public virtual TReadDto Create(TCreateDto createDto)
    {
        var entity = mapper.Map<TEntity>(createDto);
        return Create(entity);
    }

    public virtual TReadDto Create(TEntity entity)
    {
        entity = rep.Create(entity);
        return mapper.Map<TReadDto>(entity);
    }

    public virtual void Update(Guid id, TCreateDto dto)
    {
        var entity = rep.GetById(id);
        if (entity is null)
            throw new IdNotFoundException(typeof(TEntity).Name, id);
        
        entity = mapper.Map(dto, entity);
        rep.Update(entity);
    }

    public void Delete(Guid id)
    {
        var entity = rep.GetById(id);
        if (entity is null)
            throw new IdNotFoundException(typeof(TEntity).Name, id);
        
        rep.Delete(entity);
    }
}