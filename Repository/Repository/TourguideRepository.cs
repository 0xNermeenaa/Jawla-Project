﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;

namespace Repository.Repository
{
    public class TourguideRepository:GenericRepository<Tourguide,int>
    {

        private readonly AppContext _context;

        public TourguideRepository(AppContext context) : base(context)
        {
            _context = context;
        }
    }
}
