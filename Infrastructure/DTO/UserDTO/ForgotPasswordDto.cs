using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.UserDTO
{
    class ForgotPasswordDto
    {
        
        public required string Email { get; set; }
    }
}
