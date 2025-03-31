using CatStore.Entities;

namespace CatStore.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategory(int id);
        void NewCategory(Category category);
    }
}
