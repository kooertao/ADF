using ADF.Core.Model.Entities;
using System.Threading.Tasks;

namespace ADF.Core.Services.Interface
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
