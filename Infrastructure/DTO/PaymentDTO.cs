using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class PaymentDTO
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public string ProcessNumber { get; set; }

        //
        
        public int User_Id { get; set; }
        
        public int Trip_Id { get; set; }

    }
}
