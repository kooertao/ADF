using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ADFDbContext _DbContext;

        public UnitOfWork(ADFDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public void Dispose()
        {
           if(_DbContext != null)
            {
                _DbContext.Dispose();
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _DbContext.SaveChangesAsync() > 0;
        }
    }
}
