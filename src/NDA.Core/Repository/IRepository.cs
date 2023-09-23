using NDA.Core.Domain;
using NDA.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDA.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase, IAggregateRoot
    {
        TEntity FindById(Guid id);
        Task<TEntity> FindOneAsync(ISpecification<TEntity> spec);
        Task<List<TEntity>> FindAsync(ISpecification<TEntity> spec);
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
