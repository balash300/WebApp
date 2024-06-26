using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Services;


namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(IProductRepository productRepository)
        {
            _productService = new ProductService(productRepository);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            return Ok(await _productService.GetProductAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProductAsync(Product product)
        {
            return Ok(await _productService.CreateProductAsync(product));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> UpdateProductAsync(int id, Product product)
        {
            return Ok(await _productService.UpdateProductAsync(id, product));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProductAsync(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
