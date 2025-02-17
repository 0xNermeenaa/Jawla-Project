using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Tourguide
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string language { get; set; }
        public int phone { get; set; }
        public string state { get; set; }



        public virtual ICollection<CustomTrip> CustomTrips { get; set; } = new List<CustomTrip>();
        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();


    }
}
