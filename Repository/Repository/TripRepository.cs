using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class TripRepository:GenericRepository<Trip,int> ,ITripRepository
    {

        private readonly AppContext _context;

        public TripRepository(AppContext context) : base(context)
        {
            _context = context;
        }
        //-------------------------------------------
       


    }
}
