using E_Commere.Data.Base;
using E_Commere.Models;

namespace E_Commere.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>,IProductService
    {
        public ProductService(EcommerceDbContext _context) : base(_context)
        {
        }
    }
}
