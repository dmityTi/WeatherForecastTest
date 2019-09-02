using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data
{
    public interface IRepository<TModelDTO> where TModelDTO : class
    {
        void Add(TModelDTO entity);
        void AddRange(IEnumerable<TModelDTO> entities);
        void Update(TModelDTO entity);
        void Delete(TModelDTO entity);
        Task<TModelDTO> GetByIdAsync(long id);
        IEnumerable<TModelDTO> Get(Expression<Func<TModelDTO, bool>> predicate, bool noTracking = false);
        Task<IEnumerable<TModelDTO>> ListAllAsync(bool noTracking = false);
    }
}