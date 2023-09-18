namespace Furniro_back_end.Repositories
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<T> GetAllBy(Predicate<T> predicate);
        Task<IEnumerable<T>> GetAllByAsync(Predicate<T> predicate);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
