using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using AutoMapper;
using AppContext = Infrastructure.AppContext;

namespace Repository.Repository
{
    public class CarRepository : GenericRepository<Car, int>, ICarRepository
    {
        private readonly AppContext _context;

        public CarRepository(AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAvailableCarsAsync()
        {
            return await _context.Cars.Where(c => c.State == "Available").ToListAsync();
        }
    }
}
