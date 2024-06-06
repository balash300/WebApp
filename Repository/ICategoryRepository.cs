using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface ICategoryRepository
    {
        public Task<ActionResult<IEnumerable<Category>>> GetAllCategories();
        public Task<ActionResult<Category>> GetCategory(int id);
        public Task<ActionResult<IEnumerable<Category>>> CreateCategory(Category category);
        public Task<ActionResult<IEnumerable<Category>>> UpdateCategory(Category category);
        public Task<ActionResult<IEnumerable<Category>>> Delete(int id);
    }
}
