using E_Commere.Data;
using E_Commere.Data.Base;
using E_Commere.Data.Services;
using E_Commere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Controllers
{
    public class ProductsController : Controller
    {
        private readonly  IProductService service;
        private readonly ICategoryServices CatServices;
        public ProductsController(IProductService _service, ICategoryServices _CarServices)
        {
              service = _service;
            CatServices = _CarServices; 
        }
        public async Task<IActionResult> Index(string SearchTerm)
        {
            var product = await service.GetAllAsync(x=> x.Category);
            if(!string.IsNullOrEmpty(SearchTerm))
            {
                product = product.Where(x=> x.Name.Contains(SearchTerm)).ToList();
            }
            return View(product);
        }
        public async Task<IActionResult>Details(int id)
        {
            var product = await service.GetByIdAsync(id,x=> x.Category);
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult>Create()
        {
            ViewBag.CategoryId = await CatServices.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await service.CreateAsync(product);
                await service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NotFound");
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            ViewBag.CategoryId = await CatServices.GetAllAsync();
            var productId = await service.GetByIdAsync(id, x=> x.Category);
            return View(productId);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(product);
                await service.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);

        }
        public async Task<IActionResult>Delete(int id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
