using System.ComponentModel.DataAnnotations;

namespace Jawla.Models
{
    public class PlacesImage
    {

        [Key]
        public int Id { get; set; }

        public string main_image { get; set; }
        public string image { get; set; }
        public ICollection<Trip> Trip { get; set; } = new List<Trip>();
    }
}
