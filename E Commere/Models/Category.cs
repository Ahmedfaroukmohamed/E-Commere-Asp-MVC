using System.ComponentModel.DataAnnotations;

namespace E_Commere.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is rquired")]
        [StringLength(20, ErrorMessage = "This {0} Must be between {2},{1}", MinimumLength = 3)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public string Description { get; set; } 
        public ICollection<Product> Products { get; set; } 
    }
}
