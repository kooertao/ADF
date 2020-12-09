using ADF.Core.Data;
using ADF.Core.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ADFDbContext _DbContext;
        private ProductRepository _ProductRepository;

        private ProductCategoryRepository _ProductCategoryRepository;

        //repository lere ulaşmak için nesneler tanımlandı

        public IProductRepository Products => _ProductRepository = _ProductRepository ?? new ProductRepository(_DbContext);

        public IProductCategoryRepository ProductCategories => _ProductCategoryRepository = _ProductCategoryRepository ?? new ProductCategoryRepository(_DbContext);

        public UnitOfWork(ADFDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public bool Commit()
        {
           return _DbContext.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
           return await _DbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
           if(_DbContext != null)
            {
                _DbContext.Dispose();
            }
        }
    }
}
