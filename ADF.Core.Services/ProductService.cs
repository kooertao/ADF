using ADF.Core.Data;
using ADF.Core.Model.Entities;
using ADF.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _repository;

        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
