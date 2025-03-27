using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class CustomTripDTO
    {
        public int? Id { get; set; }
        public int? Car { get; set; }
        public string? CarTyp { get; set; }
        public int? Tourguide { get; set; }
        public string? TourguideLanguge { get; set; }

        public int? Days { get; set; }
        public int? NumberOfParticipants { get; set; }
        

        public string State { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<string>? Locations { get; set; }

        public int userid { get; set; }


    }
    //
    public class AdminCustomTripDTO
    {
        public bool Ok { get; set; }
        public int Id { get; set; }
        public List<int>? CarsIds { get; set; }
        public List <int>? TourguidesIds { get; set; }
        public int? Price { get; set; }

    }

    //

    public class AllCustomTripDTO
    { 
        
        public int Id { get; set; }
        public string State { get; set; }

        public DateTime StartTime { get; set; }
        public string StartLocation { get; set; }

    }



}
