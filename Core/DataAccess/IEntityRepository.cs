using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class,new()
    {
        TEntity Create(TEntity entity);
        TEntity Update(string id,TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> filter);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter=null);
    }
}
