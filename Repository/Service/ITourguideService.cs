using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository.Service;
using System.Threading.Tasks;


namespace Repository.Service
{
    public interface ITourguideService
    {
        Task<List<TourguideDTO>> GetAllTourguidesAsync();
        Task<TourguideDTO> GetTourguideByIdAsync(int id);
        Task<TourguideDTO> AddTourguideAsync(TourguideDTO tourguideDTO);
        Task<bool> UpdateTourguideAsync(TourguideDTO tourguideDTO);
        Task<bool> DeleteTourguideAsync(int id);
    }
}
