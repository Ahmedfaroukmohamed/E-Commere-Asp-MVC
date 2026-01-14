
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace E_Commere.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepostory<T> where T : class, IBaseEntity
    {
        readonly private EcommerceDbContext context;
        readonly private DbSet<T> entity;
        public EntityBaseRepository(EcommerceDbContext _context) 
        {
            context = _context;
            entity = context.Set<T>();  
        }
        public async Task CreateAsync(T category)
        {
             await entity.AddAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var CategoryId = await entity.FirstOrDefaultAsync(c => c.Id == id);
            if (CategoryId != null)
            {
                entity.Remove(CategoryId);
                await SaveChanges();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            =>await entity.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
             IQueryable<T> query = entity.AsQueryable();
            query = include.Aggregate(query,(current ,include)=> current.Include(include));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = entity.AsQueryable();
            query = include.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(x=> x.Id==id);
        }

        public async Task<T> GetByIdAsync(int id)
            => await entity.FirstOrDefaultAsync(x=> x.Id==id);

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T category)
        {
            EntityEntry entityEntry = context.Entry<T>(category);
            entityEntry.State = EntityState.Modified;
            await SaveChanges();
        }
    }
}
