using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class ProductRepository : ControllerBase, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return Ok(await _context.Products.Include(p => p.Categories).ToListAsync());
        }

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var data = await _context.Products.FindAsync(id);

            if (data.Equals(null))
                return NotFound("Data not found...");

            return Ok(data);
        }

        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.Include(p => p.Categories).ToListAsync());
        }

        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct(Product product)
        {
            var dbProducts = await _context.Products.FindAsync(product.Id);

            if (dbProducts is null)
                return NotFound("Product not found...");

            dbProducts.Name = product.Name;
            dbProducts.Description = product.Description;
            dbProducts.Price = product.Price;
            dbProducts.StockQuantity = product.StockQuantity;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.Include(p => p.Categories).ToListAsync());
        }

        public async Task<ActionResult<IEnumerable<Product>>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product.Equals(null))
                return NotFound("Data not found...");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.Include(p => p.Categories).ToListAsync());
        }
    }
}
