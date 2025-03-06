using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using AppContext = Infrastructure.AppContext;
namespace Repository.Repository
{
    public class GenericRepository<T, Tid> : IGenericRepository<T, Tid> where T : class
    {

        private readonly AppContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        //--------------------------------------------------------------------------




        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        //
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        //
        public async Task<T> GetByIdAsync(Tid id)
        {
            var en = await _dbSet.FindAsync(id);

            if (en == null)
            {
                throw new Exception($"Entity with ID {id} not found.");
            }

            return en;
        }
        //
        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        //
        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        //
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        //
        public async Task<bool> ExistsAsync(Tid id)
        {
            return await _dbSet.AnyAsync(entity => entity.Equals(id));
        }
        //


        public  int hg()
        {

            return (5);
            
         
        }


    }
}
