using Case.Core.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Case.Core.DataAccess
{
    public interface IBaseRepository<TEntity> where TEntity : class, IBaseModel, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int page = 1,
            int pageSize = 0,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            );
        int GetListCount(Expression<Func<TEntity, bool>> filter = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
