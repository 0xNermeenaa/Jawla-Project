using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.UserDTO
{
    public class RegisterDTO
    {

        public required string Username { get; set; }


        public required string password { get; set; }


        public required string Email { get; set; }

        public required string Phone { get; set; }
    }
}
