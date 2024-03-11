using System.Linq.Expressions;

namespace Play.Common
{
    //T is an generalization from IEntity, where in here, Item is replaced by T
    public interface IRepository<T> where T : IEntity
    {
        Task CreateAsync(T entity);

        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);

        Task<T> GetAsync(Guid id);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task removeAsync(Guid id);

        Task updateAsync(T entity);
    }
}