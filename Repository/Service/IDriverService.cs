using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Repository.Service
{
    public interface IDriverService
    {
        Task<List<DriverDTO>> GetAllDriversAsync();
        Task<DriverDTO> GetDriverByIdAsync(int id);
        Task<List<DriverDTO>> GetDriversByCarIdAsync(int carId);
        Task<DriverDTO> AddDriverAsync(DriverDTO driverDTO);
        Task<bool> UpdateDriverAsync(DriverDTO driverDTO);
        Task<bool> DeleteDriverAsync(int id);
    }
}
