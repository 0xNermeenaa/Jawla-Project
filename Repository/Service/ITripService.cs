using Infrastructure.DTO.TripDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO.TripDTO;
using Infrastructure.Models;
namespace Repository.Service
{
    public interface ITripService
    {
        Task <List<AllTripsDTO>> GetAllTripsAsync();

        Task<TripDetailsDTO> GetTripDetailsAsync(int id);
        Task<Trip> AddTripِAsync(AddUpdateTripDTO trip);
        Task<bool> DeleteTripAsync(int id);
        Task<bool> UpdateTripAsync(AddUpdateTripDTO trip);


    }
}
