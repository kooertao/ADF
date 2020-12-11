using ADF.Core.Model.Entities;
using ADF.Core.Services.Interface;
using ADF.CoreApi.DTO;
using ADF.CoreApi.Filter;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADF.CoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireAdminRole")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _ProductService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _ProductService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _ProductService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(products));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var created = await _ProductService.AddAsync(_mapper.Map<Product>(productDto));

            return Created(string.Empty, _mapper.Map<ProductDto>(created));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {

            var updated = _ProductService.Update(_mapper.Map<Product>(productDto));

            return NoContent();

        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deleted = _ProductService.GetByIdAsync(id).Result;
            _ProductService.Remove(deleted);

            return NoContent();
        }


        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetCategoriesById(int id)
        {
            var product = await _ProductService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));

        }

    }
}