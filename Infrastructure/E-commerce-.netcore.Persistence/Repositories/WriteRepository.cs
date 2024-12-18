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
    public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase
    {
        private readonly DbContext dbContext;
        public WriteRepository(DbContext dbContext) { 
           this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }
        public async Task AddAsync(T entity)
        {
           await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(()=>Table.Update(entity));
            return entity;

        }
    }
}
