using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class CustomTrip
    {
        public int Id { get; set; }
        public int? Car {get; set; }
        public string? CarTyp { get; set; }
        public int? Tourguide {get; set; }
        public string? TourguideLanguge { get; set; }

        public int? Days { get; set; }
        public int? NumberOfParticipants { get; set; }
        public int Price { get; set; }

        public string State { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string>? Locations { get; set; }

        
        [ForeignKey("User")]
        public int userid { get; set; }
        public User User { get; set; }
        

        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
        public virtual ICollection<Tourguide> Tourguides { get; set; } = new List<Tourguide>();



    }
}
