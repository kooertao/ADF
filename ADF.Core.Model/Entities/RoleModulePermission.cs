using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Entities
{
    public class RoleModulePermission : BaseEntity
    {
        public RoleModulePermission()
        {
            //this.Role = new Role();
            //this.Module = new Module();
            //this.Permission = new Permission();

        }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int PermissionId { get; set; }

        public bool? IsDeleted { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; } = DateTime.Now;
        public Role Role { get; set; }
        public Modules Module { get; set; }
        public Permission Permission { get; set; }
    }
}
