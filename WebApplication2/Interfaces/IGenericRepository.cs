﻿using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace WebApplication2.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<T?> GetById(Guid Id);
        Task<T?> FindFirst(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetPagedResult(IQueryable<T> entity, int? page, int? count);

        Task Add(T entity, CancellationToken cancellationToken = default);
        Task AddRange(IEnumerable<T> entity, CancellationToken cancellationToken = default);

        Task Update(T entity, CancellationToken cancellationToken = default);
        Task UpdateRange(IEnumerable<T> entity, CancellationToken cancellationToken = default);

        Task Delete(T entity, CancellationToken cancellationToken = default);
        Task DeleteRange(IEnumerable<T> entity, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
