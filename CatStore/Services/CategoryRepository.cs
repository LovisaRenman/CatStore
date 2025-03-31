using CatStore.Context;
using CatStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatStore.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatContext _context;

        public CategoryRepository(CatContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void NewCategory(Category category)
        {
            _context.Categories.AddAsync(category);
            _context.SaveChangesAsync();
        }
    }
}
