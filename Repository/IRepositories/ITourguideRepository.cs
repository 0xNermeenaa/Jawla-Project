using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Repository.IRepositories
{
    public interface ITourguideRepository : IGenericRepository<Tourguide, int>
    {
        Task<bool> DeleteAsync(int id);

        // Example of a custom method; add more if needed
        Task<List<Tourguide>> GetTourguidesByStateAsync(string state);
    }
}
