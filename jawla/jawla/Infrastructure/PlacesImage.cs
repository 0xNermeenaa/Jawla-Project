using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class PlacesImage
    {
        public int Id { get; set; }
        public string main_image { get; set; }
        public string image { get; set; }

        //
        public Trip Trip { get; set; }
    }
}
