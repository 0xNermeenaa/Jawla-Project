using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jawla.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
       /* [ForeignKey("Payment")]
        public int Payment_id { get; set; }*/
        // public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
