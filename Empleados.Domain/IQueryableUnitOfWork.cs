using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Empleados.Domain
{
    public interface IQueryableUnitOfWork: IDisposable
    {
        void Commit();
        Task CommitAsync();
        DbContext GetContext();
        DbSet<TEntity> GetSet<TEntity>() where TEntity : class;
    }
}