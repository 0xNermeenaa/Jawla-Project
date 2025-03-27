using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DTO.TripDTO;

namespace Repository.Repository
{
    public class TripRepository:GenericRepository<Trip,int> ,ITripRepository
    {

        private readonly AppContext _context;
        private readonly DbSet<Trip> _dbSet;

        public TripRepository(AppContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Trip>();

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





        public async Task<Trip> GetTripAdmin(int id)
        {
            return await _dbSet
                .Include(t => t.Images)           // تضمين الصور
                .Include(t => t.Tourguides)       // تضمين المرشدين السياحيين
                .Include(t => t.Cars)            // تضمين السيارات
                .FirstOrDefaultAsync(t => t.Id == id); // البحث حسب الـ Id
        }

        /*
                public async Task<Trip>Add(AddUpdateTripDTO trip)
                {


                    if (trip.CarIds != null && trip.CarIds.Any())
                    {
                        var cars = await _context.Cars
                            .Where(c => trip.CarIds.Contains(c.Id))
                            .ToListAsync();


                    }

                    if (trip.Tourguideids != null && trip.Tourguideids.Any())
                    {
                        var tourguides = await _context.Tourguides
                            .Where(tg => tripDto.Tourguideids.Contains(tg.Id))
                            .ToListAsync();

                        tripModel.Tourguides = tourguides;
                    }
                }
        */


        public async Task<Trip> GetTripWithReservationsAsync(int tripId)
        {
            return await _context.Trips
                .Include(t => t.Reservations)
                .FirstOrDefaultAsync(t => t.Id == tripId);
        }



        


        public async Task<List<Reservation>> GetTripReservationsAsync(int tripId)
        {
            var reservations = await _context.Reservations
                .Where(r => r.Trip_Id == tripId)
                .ToListAsync();

            return reservations ?? new List<Reservation>(); // إرجاع قائمة فارغة إذا لم يكن هناك نتائج
        }

    }
}
