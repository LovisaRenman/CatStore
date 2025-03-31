using CatStore.Entities;

namespace CatStore.Models;

public class CustomerDto
{
    public CustomerDto(Customer customer)
    {
        Id = customer.Id;
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        Email = customer.Email;
        MobilNumber = customer.MobilNumber;
        Adress = customer.Adress;
        Products = customer.Products.Select(p => new ProductDto(p)).ToList() ?? new List<ProductDto>();
    }

    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? MobilNumber { get; set; }

    public string? Adress { get; set; }
    public virtual ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
}
