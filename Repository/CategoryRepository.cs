using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CategoryRepository : ControllerBase, ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var data = await _context.Categories.FindAsync(id);

            if (data.Equals(null))
                return NotFound("Data not found...");

            return Ok(data);
        }

        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return Ok(await _context.Categories.Include(c => c.Products).ToListAsync());
        }

        public async Task<ActionResult<IEnumerable<Category>>> CreateCategory(Category category)
        {
            var data = _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return Ok(await _context.Categories.Include(c => c.Products).ToListAsync());
        }

        public async Task<ActionResult<IEnumerable<Category>>> UpdateCategory(Category category)
        {
            var data = _context.Categories.FindAsync(category.Id);

            if (data.Equals(null))
                return NotFound("Data not found...");

            data.Result.Name = category.Name;
            data.Result.Description = category.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Categories.Include(c => c.Products).ToListAsync());
        }

        public async Task<ActionResult<IEnumerable<Category>>> Delete(int id)
        {
            var data = _context.Categories.FindAsync(id);

            if (data.Equals(null))
                return NotFound("Data not found...");

            _context.Categories.Remove(data.Result);
            await _context.SaveChangesAsync();

            return Ok(await _context.Categories.Include(c => c.Products).ToListAsync());
        }
    }
}
