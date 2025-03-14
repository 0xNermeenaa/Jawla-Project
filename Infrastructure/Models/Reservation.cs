using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("User")]
        public string User_Id { get; set; }
        [ForeignKey("Trip")]
        public int Trip_Id { get; set; }


        public User User { get; set; }
        public Trip Trip { get; set; }

        public DateTime DateTime { get; set; }
    }
}
