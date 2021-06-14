﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Empleados.Domain.IRepository
{
    public interface IERepository<TEntity> : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task ExecuteSqlCommandAsync(string query, params object[] parameters);
        Task<IEnumerable<TEntity>> ExecuteStoredProcedureAsync(string query, params object[] parameters);
        Task<TEntity> FindByIdAsync(dynamic id);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<IEnumerable<TEntity>> GetAllPagedAsync(int take, int skip, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
