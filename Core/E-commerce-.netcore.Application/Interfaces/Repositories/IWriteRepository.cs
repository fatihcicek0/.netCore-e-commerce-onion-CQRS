using E_commerce_.netcore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Interfaces.Repositories
{
    public  interface IWriteRepository<T> where T : EntityBase
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
