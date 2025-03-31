using CatStore.Entities;

namespace CatStore.Services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetAllProductsByNameAsync(string productName);
        Task<Product?> GetProduct(int productId);
        Product? DeleteProduct(int id);
        Product? UpdateProduct(Product product);
        void NewProduct(Product product);
    }
}
