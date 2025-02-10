using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CustomTrip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Days { get; set; }
        public int NumberOfParticipants { get; set; }
        public int Price { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }



        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User { get; set; }


        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
        public virtual ICollection<Tourguide> Tourguides { get; set; } = new List<Tourguide>();



    }
}
