using ADF.Core.Model.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADF.Core.Repository
{
    public interface IFamilyRepository : IBaseRepository<Family>
    {
        Task<Family> Get(Expression<Func<Family, bool>> predicate, bool includeNestedObject);
    }
}
