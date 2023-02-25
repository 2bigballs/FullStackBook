using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class 
    {
        protected readonly ApplicationContext _db;
        private readonly DbSet<T> _table;
        public GenericRepository(ApplicationContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
