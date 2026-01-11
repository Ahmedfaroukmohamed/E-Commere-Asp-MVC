using E_Commere.Data;
using E_Commere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceDbContext _context;
        public ProductsController(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _context.Products.Include(x=> x.Category)
                .OrderBy(x=> x.Price)
                .ToListAsync();
            return View(product);
        }
    }
}
