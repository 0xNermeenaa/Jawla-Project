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
    public class DriverRepository:GenericRepository<Driver,int>,IDriverRepository
    {

        private readonly AppContext _context;

        public DriverRepository(AppContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Driver>> GetDriversByCarIdAsync(int carId)
        {
            return await _context.Drivers.Where(d => d.Car_Id == carId).ToListAsync();
        }
    }
}
