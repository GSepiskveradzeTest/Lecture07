﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using WebApplication2.Interfaces;

namespace WebApplication2.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FirstDbContext context;
        public GenericRepository(FirstDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<bool> Any(Expression<Func<T, bool>> predicate) => await context.Set<T>().AnyAsync(predicate);

        public virtual async Task<T?> GetById(Guid Id) => await context.Set<T>().FindAsync(Id);
        public virtual async Task<T?> FindFirst(Expression<Func<T, bool>> predicate) => await context.Set<T>().FirstOrDefaultAsync(predicate);

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().ToListAsync();
        public virtual async Task<IEnumerable<T>> GetAllWhereAsync(Expression<Func<T, bool>> predicate) => await context.Set<T>().Where(predicate).ToListAsync();

        public virtual IQueryable<T> GetAll() => context.Set<T>();
        public virtual IQueryable<T> GetAllWhere(Expression<Func<T, bool>> predicate) => context.Set<T>().Where(predicate);

        public virtual IQueryable<T> GetPagedResult(IQueryable<T> entity, int? page, int? count)
        {
            if (page < 0) page = 0;
            var countValue = count ?? 10;
            var pageValue = (page.HasValue && page > 0) ? (page.Value - 1) * countValue : 0;
            return entity.Skip(pageValue).Take(countValue);
        }

        public virtual async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return;
            await context.Set<T>().AddAsync(entity);
            await this.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task AddRange(IEnumerable<T> entity, CancellationToken cancellationToken = default)
        {
            if (!entity.Any()) return;
            await context.Set<T>().AddRangeAsync(entity);
            await this.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Update(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return;
            context.Set<T>().Update(entity);
            await this.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task UpdateRange(IEnumerable<T> entity, CancellationToken cancellationToken = default)
        {
            if (!entity.Any()) return;
            context.Set<T>().UpdateRange(entity);
            await this.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task Delete(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) return;
            context.Set<T>().Remove(entity);
            await this.SaveChangesAsync(cancellationToken);
        }
        public virtual async Task DeleteRange(IEnumerable<T> entity, CancellationToken cancellationToken = default)
        {
            if (!entity.Any()) return;
            context.Set<T>().RemoveRange(entity);
            await this.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (context.Database.CurrentTransaction != null)
            {
                return context.Database.CurrentTransaction;
            }
            return await context.Database.BeginTransactionAsync();
        }
    }
}
