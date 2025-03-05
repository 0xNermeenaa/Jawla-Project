using System.ComponentModel.DataAnnotations.Schema;

namespace Jawla.Models
{
    public class Book
    {
        
        public int UserId { get; set; }
        
        public int TripId { get; set; }

        public DateTime BookingDate { get; set; } = DateTime.UtcNow;

     /// <summary>
     /// ///
     /// </summary>
        public User User { get; set; }

        //public Trip Trip { get; set; }
    }
}
