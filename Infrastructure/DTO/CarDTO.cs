using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class CarDTO
    {
        public int? Id { get; set; }
        public string State { get; set; }
        public int Capacity { get; set; }
        public string License { get; set; }
        //public List<DriverDTO> Drivers { get; set; } = new List<DriverDTO>();
    }
}
