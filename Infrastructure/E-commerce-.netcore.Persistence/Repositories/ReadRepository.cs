using E_commerce_.netcore.Application.Interfaces.Repositories;
using E_commerce_.netcore.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase
    {

        private readonly DbContext dbContext;
        public ReadRepository(DbContext dbContext) { 
           this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public async Task<IList<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if(!enableTracking)  queryable.AsNoTracking();
            if(include is not null) queryable = include(queryable);
            if (predicate is not null) queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();
            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, int currentPage=1, int pageSize=5, bool enableTracking = false)
        {
            IQueryable<T> queryable= Table;
            if (!enableTracking) queryable.AsNoTracking();
            if (include is not null) include(queryable);
            if (predicate is not null) queryable.Where(predicate);
            if(orderBy is not null )
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if(!enableTracking) queryable=queryable.AsNoTracking();
            if (include is not null) queryable=include(queryable);
            queryable=queryable.Where(predicate);
            return await queryable.FirstOrDefaultAsync();
           
        }
    }
}
