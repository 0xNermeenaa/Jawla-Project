using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class AllTripsDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string? Description { get; set; }

         //public int Price { get; set; }
        //public int Duration { get; set; }
        public string Main_Image { get; set; }




    }
}
