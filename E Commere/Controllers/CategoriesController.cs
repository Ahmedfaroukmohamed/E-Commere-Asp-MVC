using E_Commere.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly EcommerceDbContext _context;
        public CategoriesController(EcommerceDbContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories =await _context.Categories.ToListAsync();
            return View(categories);
        }
    }
}
