using ADF.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Repository
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        private ADFDbContext _DbContext;
        public MemberRepository(ADFDbContext dbContext) : base(dbContext)
        {
            _DbContext = dbContext;
        }
    }
}
