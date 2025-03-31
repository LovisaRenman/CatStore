using CatStore.Entities;

namespace CatStore.Models
{
    public class ProductDto
    {
        public ProductDto(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            CategoryId = product.CategoryId;
            Status = product.Status;
            Customers = product.Customers.Select(c => new CustomerDto(c)).ToList() ?? new List<CustomerDto>();
        }

        public ProductDto()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int Price { get; set; }

        public int? CategoryId { get; set; }

        public bool Status { get; set; }
        public virtual ICollection<CustomerDto> Customers { get; set; } = new List<CustomerDto>();

    }
}
