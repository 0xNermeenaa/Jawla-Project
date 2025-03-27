using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class reservationDTO
    {


       


        public int User_Id { get; set; }
        public int Trip_Id { get; set; }
        public int PaymentId { get; set; }


        public DateTime DateTime { get; set; }



    }
}
