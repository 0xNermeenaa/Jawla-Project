using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class CustomTripDTO
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



    }
}
