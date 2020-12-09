using System;
using System.Collections.Generic;
using System.Text;

namespace ADF.Core.Model.Entities
{
    public class ProductCategory : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
