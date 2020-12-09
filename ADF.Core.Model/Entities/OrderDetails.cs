using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Entities
{
    public class OrderDetail : BaseEntity<long>
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
