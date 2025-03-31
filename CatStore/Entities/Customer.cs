using CatStore.Models;

namespace CatStore.Entities
{
    public partial class Customer
    {
        public Customer(CustomerDto customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            MobilNumber = customer.MobilNumber;
            Adress = customer.Adress;
            Products = customer.Products?.Select(p => new Product(p)).ToList() ?? new List<Product>();
        }
        public Customer()
        {
            
        }

        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int? MobilNumber { get; set; }

        public string? Adress { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
