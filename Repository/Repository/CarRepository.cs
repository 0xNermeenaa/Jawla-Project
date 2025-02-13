using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Infrastructure;
using Infrastructure.Models;
using AppContext = Infrastructure.AppContext;

namespace Repository.Repository
{
    public class CarRepository : GenericRepository<Car, int>
    {
        private readonly AppContext _context;

        public CarRepository(AppContext context) : base(context)
        {
            _context = context;
        }
    }


}
}
