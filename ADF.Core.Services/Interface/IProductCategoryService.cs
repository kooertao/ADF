using ADF.Core.Model.Entities;
using System.Threading.Tasks;

namespace ADF.Core.Services.Interface
{
    public interface IProductCategoryService : IService<ProductCategory>
    {
        Task<ProductCategory> GetWithProductsByIdAsync(int categoryId);
    }
}
