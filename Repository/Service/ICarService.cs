using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Repository.Service
{
  public interface ICarService
    {
        Task<List<CarDTO>> GetAllCarsAsync();
        Task<CarDTO> GetCarByIdAsync(int id);
        Task<List<CarDTO>> GetAvailableCarsAsync();
        Task<CarDTO> AddCarAsync(CarDTO carDTO);
        Task<bool> UpdateCarAsync(CarDTO carDTO);
        Task<bool> DeleteCarAsync(int id);
    }
}
