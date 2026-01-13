using E_Commere.Data.Base;
using E_Commere.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commere.Models
{
    public class Product :IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public ProductColor productColor { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey (nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
