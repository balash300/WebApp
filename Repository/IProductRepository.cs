using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IProductRepository
    {
        public Task<ActionResult<IEnumerable<Product>>> GetAllProducts();
        public Task<ActionResult<Product>> GetProduct(int id);
        public Task<ActionResult<IEnumerable<Product>>> CreateProduct(Product product);
        public Task<ActionResult<IEnumerable<Product>>> UpdateProduct(Product product);
        public Task<ActionResult<IEnumerable<Product>>> DeleteProduct(int id);
    }
}
