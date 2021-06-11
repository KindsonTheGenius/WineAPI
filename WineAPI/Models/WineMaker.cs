using System;
using System.Collections.Generic;

namespace WineAPI.Models
{
    public class WineMaker
    {
        public int WineMakerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<WineBottle> WineBottles { get; set; }

        public WineMaker()
        {
        }

        public WineMaker(int wineMakerId, string name, string address, ICollection<WineBottle> wineBottles)
        {
            WineMakerId = wineMakerId;
            Name = name;
            Address = address;
            WineBottles = wineBottles;
        }
    }
}
