using E_Commere.Migrations;
using E_Commere.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Data.Cart
{
    public class ShoppingCart
    {
        readonly private EcommerceDbContext context;
        public string ShoppingCartId { get; set; }
        public ShoppingCart(EcommerceDbContext _context)
        {
            context = _context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            var session = serviceProvider.GetRequiredService<IHttpContextAccessor>
                ().HttpContext.Session;
            var context = serviceProvider.GetRequiredService<EcommerceDbContext> ();
            string cartId = session.GetString("CartId")??Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public int GetShoppingTotalAmount()
        {
            return context.shoppingCartItems.Where(x=> x.ShoppingCartId == ShoppingCartId)
            .Select(x=> x.Amount).Sum();
        }
        public List<ShoppingCartItem> GetshoppingCartItems()
        {
            return context.shoppingCartItems.Where(x=> x.ShoppingCartId == ShoppingCartId)
                .Include(x=> x.Product).ToList();
        }

        public double GetShoppingCartTotal()
            => context.shoppingCartItems.Where(x=> x.ShoppingCartId== ShoppingCartId)
                .Select(x=> x.Product.Price*x.Amount).Sum();

        public async Task AddItemToShoppingCart(Product product)
        {
            var ShoppingCartItem = await context.shoppingCartItems.FirstOrDefaultAsync(x => x.ShoppingCartId == ShoppingCartId
            && x.Product.Id == product.Id);
            if (ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                await context.shoppingCartItems.AddAsync(ShoppingCartItem);
                await context.SaveChangesAsync();
            }
            else
            {
                ShoppingCartItem.Amount += 1;
            }
            await context.SaveChangesAsync();
        }
        public async Task RemoveItemFromShoppingCart(Product product)
        {
            var ShoppingCartItem = await context.shoppingCartItems.FirstOrDefaultAsync(x => x.ShoppingCartId == ShoppingCartId
            && x.Product.Id == product.Id);
            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount -= 1;
                }
                else
                {
                    context.shoppingCartItems.Remove(ShoppingCartItem);
                }
                await context.SaveChangesAsync();
            }
            
        }
        public void ClearShoppingCart()
        {
            var items = context.shoppingCartItems.Where(x=> x.ShoppingCartId 
            == ShoppingCartId).ToList();
            context.shoppingCartItems.RemoveRange(items);
            context.SaveChanges();
        }
    }
}
