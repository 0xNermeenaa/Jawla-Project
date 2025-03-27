using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Repository.IRepositories;


namespace Repository.Repository
{
    public class ReservationRepository:GenericRepository<Reservation,int>,IReservationRepository
    {

        private readonly AppContext _context;

        public ReservationRepository(AppContext context) : base(context)
        {
            _context = context;
        }




    }
}
