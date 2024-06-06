using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProduct(id);
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct(Product product)
        {
            return await _productRepository.CreateProduct(product);
        }

        public async Task<ActionResult<IEnumerable<Product>>> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<ActionResult<IEnumerable<Product>>> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
