using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.TripDTO
{
    public class AddUpdateTripDTO
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime start_date { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public int Persons { get; set; }

        public List<int> CarIds { get; set; }
        public List<int> TourguideIds { get; set; }

        public IFormFile Main_image { get; set; }
        public List <IFormFile> Images { get; set; }

    }
}
