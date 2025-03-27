using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class PlacesImage
    {
        public int Id { get; set; }
        public string main_image { get; set; }
        public virtual List<string> Images { get; set; } = new List<string>();



        [ForeignKey("Trip")]
        public int Trib_Id { get; set; }
        [JsonIgnore]
        public Trip Trip { get; set; }
    }
}
