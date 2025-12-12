using System.Linq.Expressions;
using AcademiasAPI.Domain.Models;

namespace AcademiasAPI.Infrastructure.Repositories.Interfaces;

public interface IBaseRep<TEntity> 
    where TEntity : Base
{
    public ICollection<TEntity> Get(int page, int pageSize, out int total);
    public ICollection<TEntity> GetAll();
    public ICollection<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
    public TEntity? GetById(Guid id);
    public ICollection<TEntity> GetById(Guid[] ids);
    public TEntity Create(TEntity entity);
    public TEntity Update(TEntity entity);
    public void Delete(TEntity entity);
}