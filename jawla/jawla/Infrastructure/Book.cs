using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class Book
    {
        public User User { get; set; }
        public Trip Trip { get; set; }

        public DateTime DateTime { get; set; }
    }
}
