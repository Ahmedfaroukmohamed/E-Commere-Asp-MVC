using E_Commere.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Data.Services
{
    public class OrderService : IOrderServices
    {
        readonly private EcommerceDbContext _context;
        public OrderService(EcommerceDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrderByUserIdAsync(string userId)
        {
             return await _context.Orders
                .Include(x=> x.OrderItems)
                .ThenInclude(x=> x.Product)
                .Where(x=> x.UserId == userId)
                .ToListAsync();
        }

        public async Task StoreOrdersAsync(List<ShoppingCartItem> items, string userId)
        {
            var order = new Order
            {
                UserId = userId
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach (var item in items)
            {
                var oderItem = new OrderItem
                {
                    Amount = item.Amount,
                    Price = item.Product.Price,
                    OrderId = order.Id,
                    ProductId = item.Product.Id
                };
                await _context.OrderItems.AddAsync(oderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
