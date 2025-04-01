using CatStore.Entities;

namespace CatStore.Services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetAllProductsByNameAsync(string productName);
        Task<Product?> GetProduct(int productId);
        Task<Product?> DeleteProduct(int id);
        Task<Product?> UpdateProduct(Product product);
        Task NewProduct(Product product);
    }
}
