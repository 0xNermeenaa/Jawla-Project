namespace Jawla.Models
{
    public class Driver
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }

        // Navigation properties
        public ICollection<Car> Cars { get; set; } = new List<Car>();

    }
}
