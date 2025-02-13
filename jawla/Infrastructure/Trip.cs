using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Trip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string Description { get; set; }



        [ForeignKey("Favorets")]
        public int F_User_id { get; set; }

       // [ForeignKey("Books")]
       // public int B_User_id { get; set; }

        //
        ICollection<Car> cars { get; set; } = new List<Car>();
        ICollection<Payment> Payments { get; set; } = new List<Payment>();
        ICollection<PlacesImage> Images { get; set; } = new List<PlacesImage>();
        ICollection<Tourguide> Tourguides { get; set; } = new List<Tourguide>();
        ICollection<Book> Books { get; set; } = new List<Book>();
        ICollection<User> Favorets { get; set; } = new List<User>();


    }
}
