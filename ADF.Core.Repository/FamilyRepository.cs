using ADF.Core.Model.Entities;

namespace ADF.Core.Repository
{
    public class FamilyRepository : BaseRepository<Family>, IFamilyRepository
    {
        private ADFDbContext _DbContext;
        public FamilyRepository(ADFDbContext dbContext): base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
