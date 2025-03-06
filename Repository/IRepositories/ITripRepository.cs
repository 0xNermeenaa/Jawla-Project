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
        
    }
}
