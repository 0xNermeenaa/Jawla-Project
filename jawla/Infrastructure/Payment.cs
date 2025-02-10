﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Payment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

        //
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [ForeignKey("Trip")]
        public int Trip_Id { get; set; }
        //
        public User User { get; set; }
        public Trip Trip { get; set; }

    }
}
