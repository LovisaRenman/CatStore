
using CatStore.Context;
using CatStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatStore.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatContext _context;

        public ProductRepository(CatContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Product? DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return product;
            _context.Products.Remove(product);
            _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.OrderBy(p => p.CategoryId).ThenBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByNameAsync(string productName)
        {
            return await _context.Products.Where(p => p.Name.Contains(productName)).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product?> GetProduct(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public void NewProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChangesAsync();
        }

        public Product? UpdateProduct(Product product)
        {
            var oldproduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (oldproduct != null)
            {
                _context.Products.Update(oldproduct);
                oldproduct = product;
                _context.SaveChangesAsync();
                return product;
            }
            else return oldproduct;
        }
    }
}
