namespace Jawla.Models
{
    public class Favorite
    {
        public int UserId { get; set; }
        public int TripId { get; set; }
        ////////
        /// <summary>
        /// 
        /// </summary>
        public User User { get; set; }

       // public Trip Trip { get; set; }

    }
}
