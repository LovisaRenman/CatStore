
namespace CatStore.Models;

public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Price { get; set; }

    public int? CategoryId { get; set; }

    public bool Status { get; set; }
    public virtual ICollection<CustomerDto> Customers { get; set; } = new List<CustomerDto>();

}
