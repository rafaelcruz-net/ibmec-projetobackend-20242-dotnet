using System.Linq.Expressions;

namespace SampleWebApi.Repository
{
    public interface IUnitOfWork<T>
    {
        Task SaveAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(Guid id);
        Task<IList<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllByCriteria(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(Guid id);



        
    }
}
