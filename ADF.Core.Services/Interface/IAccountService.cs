using ADF.Core.Model.Contract.Request;
using ADF.Core.Model.Contract.Response;
using ADF.Core.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public interface IAccountService : IBaseServices<Family>
    {
        Task<bool> CreateMemberAsync(string name, CreateMemberRequest request);
        void CreateFamily(Family family);
        Task<List<MemberViewModel>> GetAllMembersAsync(string familyName);
    }
}
