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
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryService = new CategoryService(categoryRepository);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryAsync(int id)
        { 
            return Ok(await _categoryService.GetCategoryAsync(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Category>>> CreateCategoryAsync(Category category)
        {
            return Ok(await _categoryService.CreateCategoryAsync(category));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> UpdateCategoryAsync(int id, Category updateCategory)
        {
            return Ok(await _categoryService.UpdateCategoryAsync(id, updateCategory));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> DeleteCategoryAsync(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
