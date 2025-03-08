using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    

    public class AppContext : IdentityDbContext<User>
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = jawlaDb; Integrated Security = True; Encrypt=False");
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }



        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Tourguide> Tourguides { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<CustomTrip> CustomTrips { get; set; }
        public virtual DbSet<Car> Cars { get; set; }




    }
}
