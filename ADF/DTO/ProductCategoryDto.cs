using System.ComponentModel.DataAnnotations;

namespace ADF.CoreApi.DTO
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
