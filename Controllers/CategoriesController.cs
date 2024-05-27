using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categories>>> GetAllCategories()
        {
            var categories = await _context.Categories.Include(p => p.Products).ToListAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category is null)
                return NotFound("Category not found...");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Categories>>> CreateCategory(Categories categories)
        {
            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();

            return Ok(await _context.Categories.Include(p => p.Products).ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Categories>>> UpdateCategory(Categories updateCategories)
        {
            var dbCategories = await _context.Categories.FindAsync(updateCategories.Id);

            if (dbCategories is null)
                return NotFound("Category not found...");

            dbCategories.Name = updateCategories.Name;
            dbCategories.Description = updateCategories.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Categories.Include(p => p.Products).ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Categories>>> DeleteCategory(int id)
        {
            var dbCategories = await _context.Categories.FindAsync(id);

            if (dbCategories is null)
                return NotFound("Category not found...");

            _context.Categories.Remove(dbCategories);
            await _context.SaveChangesAsync();

            return Ok(await _context.Categories.Include(p => p.Products).ToListAsync());
        }


    }
}
