﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }

        public required string password { get; set; }

        public required string Phone { get; set; }

        public string? Role { get; set; }




        public virtual ICollection<Trip> FavoriteTrips { get; set; } = new List<Trip>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<CustomTrip> CustomTrips { get; set; } = new List<CustomTrip>();

    }

   
}
