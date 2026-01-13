using E_Commere.Data.Base;
using E_Commere.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace E_Commere.Data.Services
{
    public class CategoryServices :  EntityBaseRepository<Category>,ICategoryServices
    {
         
        public CategoryServices(EcommerceDbContext context):base(context) { }
         
         
    }
}
