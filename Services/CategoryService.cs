using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _categoryRepository.GetCategory(id);
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        public async Task<ActionResult<IEnumerable<Category>>> CreateCategory(Category category)
        {
            return await _categoryRepository.CreateCategory(category);
        }

        public async Task<ActionResult<IEnumerable<Category>>> UpdateCategory(Category category)
        {
            return await _categoryRepository.UpdateCategory(category);
        }

        public async Task<ActionResult<IEnumerable<Category>>> DeleteCategory(int id)
        {
            return await _categoryRepository.Delete(id);
        }
    }
}
