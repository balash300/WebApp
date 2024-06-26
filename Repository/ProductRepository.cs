using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Exceptions;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(p => p.Categories).ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var data = await _context.Products.FindAsync(id);

            if (data.Equals(null))
                throw new NotFoundException("Data not found...");

            return data;
        }

        public async Task<IEnumerable<Product>> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return await _context.Products.Include(p => p.Categories).ToListAsync();
        }

        public async Task<IEnumerable<Product>> UpdateProductAsync(int id, Product product)
        {
            var dbProducts = await _context.Products.FindAsync(id);

            if (dbProducts is null)
                throw new NotFoundException("Product not found...");

            dbProducts.Name = product.Name;
            dbProducts.Description = product.Description;
            dbProducts.Price = product.Price;
            dbProducts.StockQuantity = product.StockQuantity;

            await _context.SaveChangesAsync();

            return await _context.Products.Include(p => p.Categories).ToListAsync();
        }

        public async Task<IEnumerable<Product>> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product.Equals(null))
                throw new NotFoundException("Data not found...");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
