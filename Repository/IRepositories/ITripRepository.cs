using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO.TripDTO;
using Infrastructure.Models;

namespace Repository.IRepositories
{
    public interface ITripRepository : IGenericRepository<Trip, int>
    {
        Task<List<Trip>> GetAlltripAsync();

        Task<Trip> GetTripAdmin(int id);

        Task<Trip> GetTripWithReservationsAsync(int tripId);


        Task<List<Reservation>> GetTripReservationsAsync(int tripId);
    }
}
