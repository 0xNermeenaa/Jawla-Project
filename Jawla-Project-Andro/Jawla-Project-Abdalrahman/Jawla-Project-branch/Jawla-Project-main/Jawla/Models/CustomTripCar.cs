namespace Jawla.Models
{
    public class CustomTripCar
    {

        public int CustomTripId { get; set; }
        public int CarId { get; set; }

        // Navigation properties
        public CustomTrip CustomTrip { get; set; }
        public Car Car { get; set; }

    }
}
