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

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _categoryRepository.GetCategoryAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<IEnumerable<Category>> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.CreateCategoryAsync(category);
        }

        public async Task<IEnumerable<Category>> UpdateCategoryAsync(int id, Category category)
        {
            return await _categoryRepository.UpdateCategoryAsync(id, category);
        }

        public async Task<IEnumerable<Category>> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
