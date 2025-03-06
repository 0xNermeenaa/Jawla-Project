using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IGenericRepository <T,Tid> where T : class
    {
        
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Tid id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<bool> ExistsAsync(Tid id);
        Task<int> SaveChangesAsync();

        
    }
}
