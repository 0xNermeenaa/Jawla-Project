using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;

namespace Repository.Repository
{
    public class DriverRepository:GenericRepository<Driver,int>
    {

        private readonly AppContext _context;

        public DriverRepository(AppContext context) : base(context)
        {
            _context = context;
        }
    }
}
