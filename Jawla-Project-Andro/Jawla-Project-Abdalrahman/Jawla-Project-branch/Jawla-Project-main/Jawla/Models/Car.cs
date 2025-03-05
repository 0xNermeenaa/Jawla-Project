using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jawla.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Driver")]
        public string Driver_id { get; set; }
        public string State { get; set; }
        public int Capacity { get; set; }
        public string License { get; set; }

        // Navigation properties

    }
}
