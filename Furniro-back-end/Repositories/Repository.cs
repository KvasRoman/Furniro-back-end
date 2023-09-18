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
        virtual public async void AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        virtual public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        virtual public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        virtual public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        virtual public IEnumerable<T> GetAllBy(Predicate<T> predicate)
        {
            return _dbContext.Set<T>().Where(e =>  predicate(e));
        }
        virtual public async Task<IEnumerable<T>> GetAllByAsync(Predicate<T> predicate)
        {
            return await _dbContext.Set<T>().Where(e => predicate(e)).ToListAsync();
        }
        virtual public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        virtual public async Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        virtual public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        virtual public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
