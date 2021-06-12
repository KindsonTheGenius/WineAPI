using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Seeders
{
    public class WineBottleSeeder
    {
        private readonly WineContext _context;
        public WineBottleSeeder(WineContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.WineBottle.Add(new WineBottle
            {
                WineBottleId = 1,
                Year = "2021",
                Size = 34,
                CountInCeller = 10,
                Style = Style.dry,
                Taste = "sweet, plum, cigar",
                Description = "A very nice wine",
                FoodPairing = "A good meal",
                Link = "my link",
                Image = "Great",
                WineMakerId = 1,
                WineMaker = _context.WineMaker.Find(1)
            });

            _context.SaveChanges();
        }

    }
}
