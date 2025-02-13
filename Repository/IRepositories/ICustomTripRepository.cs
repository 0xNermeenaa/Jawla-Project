using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Repository.IRepositories
{
    public interface ICustomTripRepository:IGenericRepository<CustomTrip, int>
    {
    }
}
