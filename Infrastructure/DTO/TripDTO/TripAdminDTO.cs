using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.TripDTO
{
    public class TripAdminDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime start_date { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public int Persons { get; set; }
        // public string Stste {  get; set; }
        public virtual PlacesImage Images { get; set; } = new PlacesImage();



        public List<int> carsids { get; set; }
        public List<int> Tourguideids { get; set; }
    }
}
