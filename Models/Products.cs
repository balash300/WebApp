using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; }

        public virtual Categories Categories { get; set; }

        public Products(string name, string description, int price, int stockQuantity)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            CreatedDate = DateTime.Now;
        }
    }
}
