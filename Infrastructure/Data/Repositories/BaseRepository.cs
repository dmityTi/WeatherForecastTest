using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces.Data;
using Infrastructure.Data.Context;
using Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class BaseRepository<TModelDTO, TEntity> : IRepository<TModelDTO> 
        where TEntity : class 
        where TModelDTO : class
    {
        protected readonly WeatherContext DbContext;
        
        public BaseRepository(WeatherContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public void Add(TModelDTO model)
        {
            var entity = Mapper.Map<TEntity>(model);
            DbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TModelDTO> models)
        {
            var entities = Mapper.Map<List<TEntity>>(models);
            DbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TModelDTO model)
        {
            var entity = Mapper.Map<TEntity>(model);
            DbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TModelDTO model)
        {
            var entity = Mapper.Map<TEntity>(model);
            DbContext.Set<TEntity>().Update(entity);
        }

        public async Task<TModelDTO> GetByIdAsync(long id)
        {
            var entity = await DbContext.Set<TEntity>().FindAsync(id);
            return Mapper.Map<TModelDTO>(entity);
        }

        public IEnumerable<TModelDTO> Get(Expression<Func<TModelDTO, bool>> predicate, bool noTracking = false)
        {
            var expression = Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var entities = DbContext.Set<TEntity>().Where(expression).NoTracking(noTracking).ToList();
            return Mapper.Map<List<TModelDTO>>(entities);
        }

        public async Task<IEnumerable<TModelDTO>> ListAllAsync(bool noTracking = false)
        {
            var entities = await DbContext.Set<TEntity>().NoTracking(noTracking).ToListAsync();
            return Mapper.Map<List<TModelDTO>>(entities);
        }
    }
}