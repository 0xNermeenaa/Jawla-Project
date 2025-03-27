using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Repository.IRepositories;

namespace Repository.Repository
{
    public class TourguideRepository : GenericRepository<Tourguide, int>, ITourguideRepository
    {
        private readonly AppContext _context;

        public TourguideRepository(AppContext context) : base(context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tourguide>> GetTourguidesByStateAsync(string state)
        {
            return await _context.Tourguides
                .Where(t => t.State == state)
                .ToListAsync();
        }





        //





        public async Task<List<Tourguide>> GetTourguidesByIdsAsync(List<int> tourguideIds)
        {
            return await _context.Tourguides
                .Where(tg => tourguideIds.Contains(tg.Id))
                .ToListAsync();
        }



    }
}


