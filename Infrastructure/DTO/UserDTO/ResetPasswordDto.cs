﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.UserDTO
{
    class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public required string NewPassword { get; set; }
    }
}
