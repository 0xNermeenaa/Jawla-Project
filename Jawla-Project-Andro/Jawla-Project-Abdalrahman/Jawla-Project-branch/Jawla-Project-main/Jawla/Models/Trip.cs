using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jawla.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public  string Location { get; set; }

        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string Description { get; set; }

        [ForeignKey("PlacesImage")]
        public int Places_image_id { get; set; }
        [ForeignKey("Payment")]
        public int Payment_id { get; set; }


    }
}
