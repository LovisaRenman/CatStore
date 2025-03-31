using CatStore.Entities;
namespace CatStore.Models
{
    public class CategoryDto
    {
        public CategoryDto()
        {

        }
        public CategoryDto(Category product)
        {
            Id = product.Id;
            Name = product.Name;
        }
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
