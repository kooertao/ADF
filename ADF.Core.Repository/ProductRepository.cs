using ADF.Core.Data.Interface;
using ADF.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ADF.Core.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ADFDbContext _appDbcontext { get => _context as ADFDbContext; }

        public ProductRepository(ADFDbContext context) : base(context)
        {

        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbcontext.Products.Include(x => x.ProductCategory).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
