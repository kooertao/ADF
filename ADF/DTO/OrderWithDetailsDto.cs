using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADF.CoreApi.DTO
{
    public class OrderWithDetailsDto
    {
        public decimal Discount { get; set; }
        public string Comment { get; set; }
        public List<OrderDetailsDto> orderDetails { get; set; }
    }
}
