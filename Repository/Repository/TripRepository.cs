using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class TripRepository:GenericRepository<Trip,int> ,ITripRepository
    {

        private readonly AppContext _context;

        public TripRepository(AppContext context) : base(context)
        {
            _context = context;
        }
        //-------------------------------------------

        public async Task<Trip> GetByIdAsync(int id)
        {
            return await _context.Trips
                .Include(t => t.Images) // تحميل العلاقة
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Trip>> GetAlltripAsync()
        {
            return await _context.Trips
                .Include(t => t.Images) // تحميل العلاقة
                .ToListAsync();
        }

    }
}
