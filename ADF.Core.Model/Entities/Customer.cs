using ADF.Core.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Entities
{
    public class Customer : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }


        public ICollection<Order> Orders { get; set; }
    }
}
