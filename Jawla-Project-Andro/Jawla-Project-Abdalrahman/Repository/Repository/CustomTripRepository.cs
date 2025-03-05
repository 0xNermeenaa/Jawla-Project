using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Infrastructure;

namespace Repository.Repository
{
    public class CustomTripRepository:GenericRepository<CustomTrip,int>
    {

        private readonly AppContext _context;

        public CustomTripRepository(AppContext context) : base(context)
        {
            _context = context;
        }
    }
}




