using GoldCS.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure.Repository
{
    public class BaseCrudRepository<T> : IBaseCrudRepository<T> where T : class  
    {
        private readonly GoldResourcesDbContext _context;

        public BaseCrudRepository (GoldResourcesDbContext context)
        {
            _context = context;
        }
        public async Task Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Detached;
            await _context.SaveChangesAsync();
        }
        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity); 
            await _context.SaveChangesAsync();
        }

    }
}
