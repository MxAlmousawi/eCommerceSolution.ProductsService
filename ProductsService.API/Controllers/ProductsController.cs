using System.Threading.Tasks;
using BuisnessLogicLayer.Dto;
using BuisnessLogicLayer.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService service;

        public ProductsController(IProductsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await service.GetProducts();
            return Ok(products);
        }

        [HttpGet("search/product-id/{productId}")]
        public async Task<IActionResult> GetById(Guid productId)
        {
            var product = await service.GetProductByCondition(p => p.ProductId == productId);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddRequest request)
        {
            var product = await service.AddProduct(request);
            return CreatedAtAction(nameof(GetById), new { productId = product.ProductId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateRequest request)
        {
            var updatedProduct = await service.UpdateProduct(request);
            if (updatedProduct == null)
                return NotFound();

            return Ok(updatedProduct);
        }

        [HttpGet("search/{searchSettings}")]
        public async Task<IActionResult> SearchProducts(string searchSettings)
        {
            var products =
                searchSettings == null || searchSettings.Length == 0
                    ? await service.GetProducts()
                    : await service.GetProductsByCondition(x =>
                        x.ProductName.ToLower().Contains(searchSettings.Trim().ToLower())
                    );
            return Ok(products);
        }

        [HttpDelete("product-id/{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var result = await service.DeleteProduct(productId);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
