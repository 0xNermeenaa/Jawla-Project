using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{

    

    public class AppContext : IdentityDbContext<User,IdentityRole<int>,int>
    {


        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }


        //public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<Tourguide> Tourguides { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<CustomTrip> CustomTrips { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public DbSet<HelpIssue> HelpIssues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Jawla;Integrated Security=True;Trust Server Certificate=True;");
            }
        }




    }
}
