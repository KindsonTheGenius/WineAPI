using Microsoft.EntityFrameworkCore;
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
            var wineMaker = _context.WineMaker.Find(1);
            var wineBottle = new WineBottle
            {
                WineBottleId = 1,
                Year = 2021,
                Size = 34,
                CountInCeller = 10,
                Style = Style.dry,
                Taste = "sweet, plum, cigar",
                Description = "A very nice wine",
                FoodPairing = "A good meal",
                Link = "my link",
                Image = "Great",
                WineMakerId = 1,
                WineMaker = wineMaker
            };
           // wineMaker.WineBottles.Add(wineBottle);
            AddNewWineBottle(wineBottle);

            _context.SaveChanges();

        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewWineBottle(WineBottle wineBottle)
        {
            var existingType = _context.WineBottle.FirstOrDefault(w => w.WineBottleId == wineBottle.WineBottleId);
            if (existingType == null)
            {
                _context.WineBottle.Add(wineBottle);
            }
        }

    }
}
