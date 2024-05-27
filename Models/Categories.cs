using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; }

        public virtual ICollection<Products> Products { get; set; }

        public Categories(string name, string description)
        {
            Name = name;
            Description = description;
            CreatedDate = DateTime.Now;
        }
    }
}
