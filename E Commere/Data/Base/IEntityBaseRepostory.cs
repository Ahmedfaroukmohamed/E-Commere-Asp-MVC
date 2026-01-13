using E_Commere.Models;

namespace E_Commere.Data.Base
{
    public interface IEntityBaseRepostory <T> where T : class,IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T category);
        Task UpdateAsync(T category);
        Task DeleteAsync(int id);
        Task SaveChanges();

    }
}
