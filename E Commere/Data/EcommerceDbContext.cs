using E_Commere.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options ): base(options)
            {

            }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }
    }
}
