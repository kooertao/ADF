using ADF.Core.Data.Interface;
using ADF.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ADF.Core.Data
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private ADFDbContext _appDbContext { get => _context as ADFDbContext; }

        public ProductCategoryRepository(ADFDbContext context) : base(context)
        {

        }
        public async Task<ProductCategory> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.ProductCategories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
