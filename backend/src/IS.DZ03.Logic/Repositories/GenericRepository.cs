using IS.DZ03.Logic.Repositories.Interfaces;
using IS.DZ03.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IS.DZ03.Logic.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DbContext DatabaseContext;
        protected readonly ISieveProcessor sieveProcessor;

        public GenericRepository(DbContext databaseContext, ISieveProcessor sieveProcessor)
        {
            this.DatabaseContext = databaseContext;
            this.sieveProcessor = sieveProcessor;
        }

        public void Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DatabaseContext.Set<TEntity>().AddRange(entities);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await DatabaseContext.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DatabaseContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(SieveModel model)
        {
            var result = DatabaseContext.Set<TEntity>().AsNoTracking().AsQueryable<TEntity>();
            result = sieveProcessor.Apply(model, result);
            return result;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await DatabaseContext.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DatabaseContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}
