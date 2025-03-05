using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Service
{
    public interface ITripService
    {
        Task <List<AllTripsDTO>> GetAllTripsAsync();
    }
}
