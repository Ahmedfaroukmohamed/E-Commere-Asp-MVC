using E_Commere.Data.Base;

namespace E_Commere.Models
{
    public class OrderItem : IBaseEntity
    {
        public int Id { get  ; set ; }
        public int Amount { get; set ; }
        public double Price { get; set ; }
        public int OrderId { get; set ; }
        public virtual Order Order { get; set ; }
        public int ProductId { get; set ; }
        public virtual Product Product { get; set ; }
    }
}
