using ADF.Core.Model.Entities;
using ADF.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADF.Core.Services
{
    public class RoleModulePermissionService : IBaseServices<RoleModulePermission>, IRoleModulePermissionService
    {
        public Task<List<RoleModulePermission>> GetRMPMaps()
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleModulePermission>> GetRoleModule()
        {
            throw new NotImplementedException();
        }

        public Task<List<RoleModulePermission>> RoleModuleMaps()
        {
            throw new NotImplementedException();
        }

        public Task UpdateModuleId(int permissionId, int moduleId)
        {
            throw new NotImplementedException();
        }
    }
}
