using ADF.Core.Data.Interface;
using System;
using System.Threading.Tasks;

namespace ADF.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IProductCategoryRepository ProductCategories { get; }

        Task<bool> CommitAsync();
        bool Commit();
    }
}
