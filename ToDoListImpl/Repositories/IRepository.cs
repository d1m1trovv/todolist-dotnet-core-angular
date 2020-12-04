using System.Linq;
using System.Threading.Tasks;

namespace ToDoListImpl.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        object DelegateSettings { get; }
        TEntity Settings { get; set; }
        string Type { get; }

        Task<TEntity> AddAsync(TEntity entity);
        bool Equals(object obj);
        IQueryable<TEntity> GetAll();
        int GetHashCode();
        string ToString();
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}