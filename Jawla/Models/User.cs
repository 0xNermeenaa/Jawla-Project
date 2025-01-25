namespace Jawla.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
        
        // public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
