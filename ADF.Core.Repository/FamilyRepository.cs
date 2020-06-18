using ADF.Core.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADF.Core.Repository
{
    public class FamilyRepository : BaseRepository<Family>, IFamilyRepository
    {
        private ADFDbContext _DbContext;
        public FamilyRepository(ADFDbContext dbContext): base(dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Family> Get(Expression<Func<Family, bool>> predicate, bool includeNestedObject)
        {
            if(includeNestedObject)
            {
                return _DbContext.Families.Include(f => f.Members).FirstOrDefaultAsync(predicate).Result;
            }
            else
            {
                return _DbContext.Families.FirstOrDefaultAsync(predicate).Result;
            }
        }
    }
}
