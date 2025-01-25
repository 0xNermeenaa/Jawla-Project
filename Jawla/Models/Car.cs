namespace Jawla.Models
{
    public class Car
    {

        public int Id { get; set; }
        public string Driver { get; set; }
        public string State { get; set; }
        public int Capacity { get; set; }
        public string License { get; set; }

        // Navigation properties
        public ICollection<TripCar> TripCars { get; set; } = new List<TripCar>();

    }
}
