using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }


       [ForeignKey("Favorets")]
       public int F_Trip_id { get; set; }

       // [ForeignKey("Books")]
       // public int B_Trip_id { get; set; }


        //

        public ICollection<Trip> Favorites { get; set; } = new List<Trip>();
        ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<CustomTrip> CustomTrip { get; set; } = new List<CustomTrip>();

    }
}
