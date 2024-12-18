using E_commerce_.netcore.Application.Interfaces.Repositories;
using E_commerce_.netcore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_.netcore.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable
    {

        IReadRepository<T> GetReadRepository<T>() where T : EntityBase;
        IWriteRepository<T> GetWriteRepository<T>() where T : EntityBase;

        Task<int> SaveAsync();
        int Save();

    }
}
