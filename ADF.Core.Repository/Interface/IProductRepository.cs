using ADF.Core.Model.Entities;
using System.Threading.Tasks;

namespace ADF.Core.Data.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
