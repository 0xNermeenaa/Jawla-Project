using Infrastructure.DTO.TripDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO.TripDTO;
using Infrastructure.Models;
using Infrastructure.DTO;
namespace Repository.Service
{
    public interface ITripService
    {
        Task <List<AllTripsDTO>> GetAllTripsAsync();

        Task<TripDetailsDTO> GetTripDetailsAsync(int id);
        Task<Trip> AddTripِAsync(AddUpdateTripDTO trip);
        Task<bool> DeleteTripAsync(int id);
        Task<bool> UpdateTripAsync(AddUpdateTripDTO trip);
        Task<TripAdminDTO> GetTripAdmin(int id);
        Task<bool> UpdateTripStateAsync(int tripId, string newState);
        Task<List<reservationDTO>> GetTripResevations(int tripid);

    }
}
