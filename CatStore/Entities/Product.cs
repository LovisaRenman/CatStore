using CatStore.Models;

namespace CatStore.Entities
{
    public partial class Product
    {
        public Product(ProductDto product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            CategoryId = product.CategoryId;
            Status = product.Status;
            Customers = product.Customers.Select(c => new Customer(c)).ToList() ?? new List<Customer>();
        }
        public Product()
        {
            
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int Price { get; set; }

        public int? CategoryId { get; set; }

        public bool Status { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
