using Lms.Entity.Commons;
using System.Linq.Expressions;

namespace Lms.DataAccessLayer.Abstract;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(bool tracking = true);
    Task<T> GetByIdAsync(int id);
    public IQueryable<T> GetWhereAsync(Expression<Func<T, bool>> expression);
    Task<bool> AddAsync(T entity);
    Task SaveChangesAsync(int? userId = null);
    bool Update(T entity);
    bool Remove(T entity);

    Task<IDictionary<TKey, TElement>> GetDictionaryAsync<TKey,TElement>(Func<T,TKey> keySelector,Func<T,TElement> valueSelector);

}
