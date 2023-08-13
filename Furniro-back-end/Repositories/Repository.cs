using Furniro.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Furniro_back_end.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FurniroDbContext _dbContext;

        public Repository(FurniroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
