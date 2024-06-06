using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
