using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            return await _context.Products.Include(p => p.Categories).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound("Product not found...");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Products>>> CreateProduct(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.Include(p => p.Categories).ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Products>>> UpdateProduct(Products updateProducts)
        {
            var dbProducts = await _context.Products.FindAsync(updateProducts.Id);

            if (dbProducts is null)
                return NotFound("Product not found...");

            dbProducts.Name = updateProducts.Name;
            dbProducts.Description = updateProducts.Description;
            dbProducts.Price = updateProducts.Price;
            dbProducts.StockQuantity = updateProducts.StockQuantity;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.Include(p => p.Categories).ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Products>>> DeleteProduct(int id)
        {
            var dbProducts = await _context.Products.FindAsync(id);

            if (dbProducts is null)
                return NotFound("Product not found...");

            _context.Products.Remove(dbProducts);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.Include(p => p.Categories).ToListAsync());
        }
    }
}
