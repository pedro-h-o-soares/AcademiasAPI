using System.Linq.Expressions;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Infrastructure.Database;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AcademiasAPI.Infrastructure.Repositories;

public class BaseRep<TEntity>(AcademiaContext context) : IBaseRep<TEntity>
    where TEntity : Base
{
    public virtual ICollection<TEntity> Get(int page, int pageSize, out int total)
    {
        total = context.Set<TEntity>().Count();
        return context.Set<TEntity>()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public virtual ICollection<TEntity> GetAll()
    {
        return context.Set<TEntity>()
            .ToList();
    }

    public virtual ICollection<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
    {
        return context
            .Set<TEntity>()
            .Where(predicate)
            .ToList();
    }

    public virtual TEntity? GetById(Guid id)
    {
        return context.Set<TEntity>()
            .AsTracking()
            .FirstOrDefault(e => e.Id == id);
    }

    public virtual ICollection<TEntity> GetById(Guid[] ids)
    {
        return context.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToList();
    }

    public virtual TEntity Create(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        context.SaveChanges();
        
        return entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        context.SaveChanges();
        
        return entity;
    }

    public virtual void Delete(TEntity entity)
    {
        context.Set<TEntity>()
            .Remove(entity);
    }
}