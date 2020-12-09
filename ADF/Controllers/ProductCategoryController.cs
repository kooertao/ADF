using ADF.Core.Model.Entities;
using ADF.Core.Services.Interface;
using ADF.CoreApi.DTOs;
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
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _CategoryService;
        private readonly IMapper _Mapper;

        public ProductCategoryController(IProductCategoryService categoryService, IMapper mapper)
        {
            _CategoryService = categoryService;
            _Mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _CategoryService.GetAllAsync();

            return Ok(_Mapper.Map<IEnumerable<ProductCategoryDto>>(categories));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _CategoryService.GetByIdAsync(id);

            return Ok(_Mapper.Map<ProductCategoryDto>(category));
        }

        [HttpGet("{id}/products")]

        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _CategoryService.GetWithProductsByIdAsync(id);

            return Ok(_Mapper.Map<ProductCategoryWithProductDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductCategoryDto categoryDto)
        {
            var savedcategory = await _CategoryService.AddAsync(_Mapper.Map<ProductCategory>(categoryDto));

            return Created(string.Empty, _Mapper.Map<ProductCategoryDto>(savedcategory));
        }

        [HttpPut]
        public IActionResult Update(ProductCategoryDto categoryDto)
        {
            var updated = _CategoryService.Update(_Mapper.Map<ProductCategory>(categoryDto));

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _CategoryService.GetByIdAsync(id).Result;

            _CategoryService.Remove(category);

            return NoContent();

        }
    }
}