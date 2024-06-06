using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryService = new CategoryService(categoryRepository);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        { 
            return await _categoryService.GetCategory(id);
        }
        
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Category>>> CreateCategory(Category category)
        {
            return await _categoryService.CreateCategory(category);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Category>>> UpdateCategory(Category updateCategory)
        {
            return await _categoryService.UpdateCategory(updateCategory);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Category>>> DeleteCategory(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }
    }
}
