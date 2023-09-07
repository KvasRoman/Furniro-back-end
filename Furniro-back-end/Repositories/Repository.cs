using Furniro.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Furniro_back_end.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FurniroDbContext _dbContext;

        public Repository(FurniroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        virtual public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        virtual public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        virtual public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        virtual public IEnumerable<T> GetAllBy(Predicate<T> predicate)
        {
            return _dbContext.Set<T>().Where(e =>  predicate(e));
        }

        virtual public T GetById(Guid id)
        {
            return null;
        }

        virtual public void Update(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
