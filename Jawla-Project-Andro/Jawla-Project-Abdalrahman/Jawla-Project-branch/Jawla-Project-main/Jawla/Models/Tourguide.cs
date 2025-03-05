using System.ComponentModel.DataAnnotations;

namespace Jawla.Models
{
    public class Tourguide
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

        public string language { get; set; }

        public int phone { get; set; }

        public string state {  get; set; }

        public ICollection<CustomTrip> CustomTrip { get; set; } = new List<CustomTrip>();
    }
}
