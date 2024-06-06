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
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productService.GetProduct(id);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct(Product product)
        {
            return await _productService.CreateProduct(product);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct(Product product)
        {
            return await _productService.UpdateProduct(product);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Product>>> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}
