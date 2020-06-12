using System;
using System.Threading.Tasks;

namespace ADF.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveAsync();
    }
}
