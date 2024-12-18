using E_commerce_.netcore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;


namespace E_commerce_.netcore.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : EntityBase
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include=null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false
            );
        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int currentPage=1, int pageSize=5,
            bool enableTracking = false
            );

        Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include=null,
            bool enableTracking = false
            );
    }
}
