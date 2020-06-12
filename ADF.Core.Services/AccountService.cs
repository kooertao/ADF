using System;
using System.Collections.Generic;
using System.Text;
using ADF.Core.Model.Entities;
using ADF.Core.Repository;

namespace ADF.Core.Services
{
    public class AccountService :IBaseServices<Family>, IAccountService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public IBaseRepository<Family> _FamilyRepository;//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public AccountService(IUnitOfWork unitOfWork, IBaseRepository<Family> repository)
        {
                
        }

        public void CreateFamily(Family family)
        {
            
        }
    }
}
