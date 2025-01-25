namespace Jawla.Models
{
    public class CustomTrip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Days { get; set; }
        public int NumberOfParticipants { get; set; }
       public int Price { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        ////////////////
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();



    }
}
