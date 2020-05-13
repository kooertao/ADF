using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ADF.Core.Model.Entities
{
    public class Family : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdated { get; set; }

        public List<Member> Members { get; } = new List<Member>();
    }
}
