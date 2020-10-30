using System;
using System.Collections.Generic;

namespace ADF.Core.Model.Entities
{
    public class Permission
    {
        public int Pid { get; set; }
        public int Mid { get; set; }
        public List<int> PidArr{ get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsButton { get; set; } = false;
        public bool? IsHide { get; set; } = false;
        public bool? IskeepAlive { get; set; } = false;
        public string Func { get; set; }
        public int OrderSort { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; }
        public List<string> PnameArr { get; set; } = new List<string>();
        public List<string> PCodeArr { get; set; } = new List<string>();
        public string MName { get; set; }
        public bool hasChildren { get; set; } = true;
    }
}
