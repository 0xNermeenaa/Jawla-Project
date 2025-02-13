using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string Description { get; set; }





        public virtual ICollection<Car> cars { get; set; } = new List<Car>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<PlacesImage> Images { get; set; } = new List<PlacesImage>();
        public virtual ICollection<Tourguide> Tourguides { get; set; } = new List<Tourguide>();
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<User> UsersFavorite { get; set; } = new List<User>();


    }
}
