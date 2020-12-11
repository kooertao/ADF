using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADF.CoreApi.DTO
{
    public class OrderDetailsDto
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }
    }
}
