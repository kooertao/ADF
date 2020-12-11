using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADF.CoreApi.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
       [Range(1,int.MaxValue,ErrorMessage ="Invalid stock")]
        public int Stock { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Invalid price")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
