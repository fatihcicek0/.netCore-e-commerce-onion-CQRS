using E_commerce_.netcore.Application.Interfaces.Repositories;
using E_commerce_.netcore.Application.Interfaces.UnitOfWork;
using E_commerce_.netcore.Domain.Common;
using E_commerce_.netcore.Persistence.Context;
using E_commerce_.netcore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()=>await dbContext.DisposeAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=> new ReadRepository<T>(dbContext);

         IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=>new WriteRepository<T>(dbContext);
        public int Save()=>dbContext.SaveChanges();

        public Task<int> SaveAsync()=>dbContext.SaveChangesAsync();
    }
}
