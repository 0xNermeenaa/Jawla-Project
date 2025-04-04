﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppContext = Infrastructure.AppContext;
using Infrastructure.Models;
using Infrastructure;
using Repository.IRepositories;

namespace Repository.Repository
{
    public class PaymentRepository:GenericRepository<Payment,int>,IPaymentRepository
    {
        private readonly AppContext _context;

        public PaymentRepository(AppContext context) : base(context)
        {
            _context = context;
        }
    }
}

