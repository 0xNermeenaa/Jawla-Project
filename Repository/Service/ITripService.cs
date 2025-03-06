using Infrastructure.DTO.TripDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO.TripDTO;
namespace Repository.Service
{
    public interface ITripService
    {
        Task <List<AllTripsDTO>> GetAllTripsAsync();
    }
}
