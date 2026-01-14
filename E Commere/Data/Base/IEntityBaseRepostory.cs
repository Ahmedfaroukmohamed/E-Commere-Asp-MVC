using E_Commere.Models;
using System.Linq.Expressions;

namespace E_Commere.Data.Base
{
    public interface IEntityBaseRepostory <T> where T : class,IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[]include) ;
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id,params Expression<Func<T, object>>[] include);

        Task CreateAsync(T category);
        Task UpdateAsync(T category);
        Task DeleteAsync(int id);
        Task SaveChanges();

    }
}
