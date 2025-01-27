using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(" Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True;");




        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Tourguide> Tourguides { get; set; }
        public virtual DbSet<PlacesImage> PlacesImages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<CustomTrip> CustomTrips { get; set; }
        public virtual DbSet<Car> Cars { get; set; }




    }
}
