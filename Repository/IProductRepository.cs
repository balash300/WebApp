using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<IEnumerable<Product>> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> UpdateProductAsync(int id, Product product);
        Task<IEnumerable<Product>> DeleteProductAsync(int id);
    }
}