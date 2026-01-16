using E_Commere.Data.Base;

namespace E_Commere.Models
{
    public class ShoppingCartItem : IBaseEntity
    {
        public int Id { get  ; set  ; }
        public Product Product { get ; set ; }
        public int Amount { get ; set ; }
        public string ShoppingCartId { get ; set ; }
    }
}
