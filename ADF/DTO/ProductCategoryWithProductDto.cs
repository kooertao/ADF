using System.Collections.Generic;

namespace ADF.CoreApi.DTO
{
    public class ProductCategoryWithProductDto:ProductCategoryDto
    {
        public IEnumerable<ProductDto>Products { get; set; }
    }
}
