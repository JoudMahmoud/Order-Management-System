using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Application.Interfaces;
using OrderManagementSystem.Application.Service;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Fields 
        private readonly IProductService _productService;
        #endregion

        #region Constructor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region CRUD Operation
        // Get All Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDisplayDto>>> GetAllAsync([FromQuery]string? search)
        {
            var products = await _productService.GetAllAsync(search);
            return Ok(products);
        }

        // Get Details of specific product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDisplayDto>> GetByIdAsync([FromRoute]int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound("Product not fount.");
            return Ok(product);
        }

        // Add a new product  => (Admin only)
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody]ProductDto dto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var result = await _productService.CreateAsync(dto);
            if(!result.IsSuccess) 
                return BadRequest(new {message = result.Message});

            return Ok(new { message = result.Message });

        }

        // Update product details  => (Admin only)

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]int id , [FromBody]ProductDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.UpdateAsync(id, dto);
            if(!result.IsSuccess)
                return BadRequest(new {message= result.Message});
            return Ok(new { message = result.Message });
        }

        #endregion
    }
}
