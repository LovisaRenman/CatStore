using CatStore.Models;

namespace CatStore.Entities
{
    public partial class Category
    {
        public Category(CategoryDto category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public Category()
        {
            
        }
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
