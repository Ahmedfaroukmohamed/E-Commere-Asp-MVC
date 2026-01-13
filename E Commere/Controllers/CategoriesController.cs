using E_Commere.Data;
using E_Commere.Data.Services;
using E_Commere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices services;
        public CategoriesController(ICategoryServices _services)
        {
            services = _services;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await services.GetAllAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                await services.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category =await services.GetByIdAsync(id);
            if(category != null)
            {
                return View(category);
            }
            return View("NotFound");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await services.GetByIdAsync(id);
            if (category != null)
            {
                return View(category);
            }
            return View("NotFound");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {

            if (!ModelState.IsValid) 
            {
                return View("Not Found");
            }
            await services.UpdateAsync(category);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
