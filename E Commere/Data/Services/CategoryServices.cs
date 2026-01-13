using E_Commere.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly EcommerceDbContext _context;
        public CategoryServices(EcommerceDbContext context) 
        {
            _context = context;
        }
        public async Task CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id ==id);
            if (categoryId != null)
            {
                _context.Remove(categoryId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        
             => await _context.Categories.FirstOrDefaultAsync(x=> x.Id==id);
        

        public async Task UpdateAsync(Category category)
        {
            var categoryId= await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (categoryId != null)
            {
                categoryId.Id= category.Id;
                categoryId.Name= category.Name;
                categoryId.Description= category.Description;
                await _context.SaveChangesAsync();

            }
        }
    }
}
