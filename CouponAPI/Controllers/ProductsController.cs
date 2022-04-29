using CouponCore.Dtos;
using CouponCore.Entites;
using CouponCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AddProductDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(AddProductDto product)
        {
            if (product == null)
                return BadRequest(ModelState);

            if (_productService.ProductExists(product.Name))
            {
                ModelState.AddModelError("", "Product exists!");
                return StatusCode(404, ModelState);
            }

            var response = await _productService.Add(product);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(GetProductDto))]
        public async Task<IActionResult> Get([FromQuery] ProductSearchDto req)
        {
            var response = await _productService.GetAll(req);
            return Ok(response);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(GetProductDto))]
        public async Task<IActionResult> GetById(int productId)
        {
            if (!_productService.ProductExists(productId))
                return NotFound();

            var response = await _productService.GetById(productId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(response);
        }
    }
}
