using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Exceptions;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var data = await _context.Categories.FindAsync(id);

            if (data.Equals(null))
                throw new NotFoundException("Data not found...");

            return data;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<IEnumerable<Category>> CreateCategoryAsync(Category category)
        {
            var data = _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<IEnumerable<Category>> UpdateCategoryAsync(int id, Category category)
        {
            var data = _context.Categories.FindAsync(id);

            if (data.Equals(null))
                throw new NotFoundException("Data not found...");

            data.Result.Name = category.Name;
            data.Result.Description = category.Description;

            await _context.SaveChangesAsync();

            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<IEnumerable<Category>> DeleteCategoryAsync(int id)
        {
            var data = _context.Categories.FindAsync(id);

            if (data.Equals(null))
                throw new NotFoundException("Data not found...");

            _context.Categories.Remove(data.Result);
            await _context.SaveChangesAsync();

            return null;
        }
    }
}
