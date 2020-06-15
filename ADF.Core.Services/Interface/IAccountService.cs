using ADF.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public interface IAccountService : IBaseServices<Family>
    {
        Task<bool> CreateMember(Member member);
        void CreateFamily(Family family);   
    }
}
