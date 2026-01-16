using E_Commere.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace E_Commere.Data.ViewComponents
{
    public class ShoppingCartSummery:ViewComponent
    {
        readonly private ShoppingCart _cart;
        public ShoppingCartSummery(ShoppingCart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            var item = _cart.GetShoppingTotalAmount();
            ViewBag.Total = _cart.GetShoppingCartTotal();
            return View(item);
        }
    }
}
