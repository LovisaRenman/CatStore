namespace CatStore.Models;

public class CustomerDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? MobilNumber { get; set; }

    public string? Adress { get; set; }
    public virtual ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
}
