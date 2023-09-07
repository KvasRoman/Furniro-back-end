namespace Furniro_back_end.Repositories
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAllBy(Predicate<T> predicate);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
