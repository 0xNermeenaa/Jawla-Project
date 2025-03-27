using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Infrastructure;
using Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class CustomTripRepository:GenericRepository<CustomTrip,int>,ICustomTripRepository
    {

        private readonly AppContext _context;

        public CustomTripRepository(AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CustomTrip>> GetAllWaitAsync()
        {
            var allTrips = await _context.CustomTrips.ToListAsync();

            var filteredTrips = allTrips.Where(t => t.State == "Wait").ToList();

            return filteredTrips;
        }

    }
}




