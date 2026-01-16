using E_Commere.Models;

namespace E_Commere.Data.Services
{
    public interface IOrderServices
    {
        Task StoreOrdersAsync(List<ShoppingCartItem> items, string userId );
        Task <List<Order>> GetOrderByUserIdAsync(string userId);
    }
}
