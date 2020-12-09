using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADF.CoreApi.DTOs
{
    public class ProductWithCategoryDto:ProductDto
    {
        public ProductCategoryDto ProductCategory { get; set; }
    }
}
