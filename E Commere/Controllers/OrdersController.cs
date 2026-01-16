using E_Commere.Data.Cart;
using E_Commere.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commere.Controllers
{
    public class OrdersController : Controller
    {
        readonly private IProductService _productService;
        readonly private ShoppingCart _shoppingCart;
        readonly private IOrderServices _orderServices;
        public OrdersController(IProductService productService, ShoppingCart shoppingCart, IOrderServices orderServices)
        {
            _productService = productService;
            _shoppingCart = shoppingCart;
            _orderServices = orderServices;
        }
        public async Task<IActionResult>Index()
        {
            string userId = "";
            var order =await _orderServices.GetOrderByUserIdAsync(userId);
            return View(order);
        }

        public IActionResult ShoppingCart()
        {
            var item = _shoppingCart.GetshoppingCartItems();
            ViewBag.Total =_shoppingCart.GetShoppingCartTotal();
            return View(item);
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result != null)
            {
                await _shoppingCart.AddItemToShoppingCart(result);
            }
            return RedirectToAction("ShoppingCart");
        }
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result != null)
            {
                await _shoppingCart.RemoveItemFromShoppingCart(result);
            }
            return RedirectToAction("ShoppingCart");
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var item = _shoppingCart.GetshoppingCartItems();
            string userId = "";
            await _orderServices.StoreOrdersAsync(item, userId);
            _shoppingCart.ClearShoppingCart();
            return View("CompleteOrder");
        }
    }
}
