using ADF.Core.Model.Enum;
using System;

namespace ADF.Core.Model.Entities
{
    public class Member :BaseEntity
    {
        public Gender MemberGen { get; set; }
        public string Name { get; set; }
        public bool IsEmployed { get; set; }
        public int Age { get; set; }
        public long FamilyId { get; set; }
        public string FamilyName { get; set; }
        public Family Family { get; set; }
        public DateTime CreateTime { get; set; } 
        public DateTime LastUpdated { get; set; }
    }
}
