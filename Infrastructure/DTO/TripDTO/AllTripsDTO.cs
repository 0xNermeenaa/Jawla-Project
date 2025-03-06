using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.TripDTO
{
    public class AllTripsDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public string Main_Image { get; set; }




    }
}
