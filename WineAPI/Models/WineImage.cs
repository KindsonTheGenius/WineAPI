using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Models
{
    public class WineImage
    {
        public int WineImageId { get; set; }
        public string WineImageTitle { get; set; }
        public byte[] WineImageData { get; set; }
    }
}
