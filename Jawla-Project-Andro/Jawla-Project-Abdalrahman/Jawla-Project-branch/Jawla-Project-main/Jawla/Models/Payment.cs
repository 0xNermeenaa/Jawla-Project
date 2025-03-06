namespace Jawla.Models
{
    public class Payment
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int TripId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Trip Trip { get; set; }

    }
}
