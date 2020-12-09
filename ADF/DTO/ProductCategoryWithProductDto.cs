using System.Collections.Generic;

namespace ADF.CoreApi.DTOs
{
    public class ProductCategoryWithProductDto:ProductCategoryDto
    {
        public IEnumerable<ProductDto>Products { get; set; }
    }
}
