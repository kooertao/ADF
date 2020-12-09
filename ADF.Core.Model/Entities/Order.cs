using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Entities
{
    public class Order : BaseEntity<long>
    {
        public decimal Discount { get; set; }
        public string Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public long CustomerId { get; set; }
        public Customer Customer { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
