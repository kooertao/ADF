using ADF.Core.Data;
using ADF.Core.Model.Entities;
using ADF.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public class ProductCategoryService : Service<ProductCategory>, IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductCategory> _repository;

        public ProductCategoryService(IUnitOfWork unitOfWork, IRepository<ProductCategory> repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<ProductCategory> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.ProductCategories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
