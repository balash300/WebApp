using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> CreateCategoryAsync(Category category);
        Task<IEnumerable<Category>> UpdateCategoryAsync(int id, Category category);
        Task<IEnumerable<Category>> DeleteCategoryAsync(int id);
    }
}
