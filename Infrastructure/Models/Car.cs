using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string State { get; set; }
        public int Capacity { get; set; }
        public string License { get; set; }


        public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
        public virtual ICollection<CustomTrip> CustomTrips { get; set; } = new List<CustomTrip>();
        [JsonIgnore]
        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();



    }
}
