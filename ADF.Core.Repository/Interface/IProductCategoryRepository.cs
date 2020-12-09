using ADF.Core.Model.Entities;
using ADF.Core.Data;
using System.Threading.Tasks;

namespace ADF.Core.Data.Interface
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<ProductCategory> GetWithProductsByIdAsync(int categoryId);

    }
}
