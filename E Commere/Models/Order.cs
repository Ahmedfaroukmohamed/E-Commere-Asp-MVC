using E_Commere.Data.Base;

namespace E_Commere.Models
{
    public class Order : IBaseEntity
    {
        public Order() 
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public int Id { get ; set; }
        public string UserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
