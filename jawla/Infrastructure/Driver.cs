using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }

        //
        [ForeignKey("Car")]
        public int Car_Id { get; set; }
    //
        public Car Car { get; set; }
        
    }
}
