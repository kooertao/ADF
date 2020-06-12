using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly ADFDbContext _DbContext;

        public BaseRepository(ADFDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _DbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var query = _DbContext.Set<TEntity>().AsQueryable();
            return await query.ToListAsync();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)
        {
            _DbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
