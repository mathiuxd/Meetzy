using Meetzy.Aplication.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Meetzy.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public Task<T> CreateAsync(T entity)
        {
            _dbContext.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return Task.FromResult(entity);
        }
    }

}