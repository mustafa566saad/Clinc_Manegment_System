using Clinc_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinc_Manegment_System.Repositories
{
    public class CRUDOps<T> : ICRUD<T> where T : class
    {
        private readonly ClincContext clincContext;
        private readonly DbSet<T> _dbSet;


        public CRUDOps(ClincContext clincContext)
        {
            this.clincContext = clincContext;
            _dbSet = clincContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            clincContext.SaveChanges();
        }

        public void Delete(T entity)=> _dbSet.Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync()=> await _dbSet.ToListAsync();

        public async Task<T?> GetByID(int id) => await _dbSet.FindAsync(id);

        public void Update(T entity)=> _dbSet.Update(entity);
    }
}
