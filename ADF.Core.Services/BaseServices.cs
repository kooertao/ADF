using ADF.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> _BaseRepository;//通过在子类的构造函数中注入，这里是基类，不用构造函数

        private readonly IUnitOfWork _UnitOfWork;

        public BaseServices(IUnitOfWork unitOfWork, IBaseRepository<TEntity> repository)
        {
            _BaseRepository = repository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<bool> Add(TEntity entity)
        {
            _BaseRepository.Add(entity);
            return await _UnitOfWork.SaveAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _BaseRepository.Get(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _BaseRepository.GetAll();
        }
    }
}
