using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;

namespace WineAPI.Seeders
{
    public class WineMakerSeeder
    {
        private readonly WineContext _context;
        public WineMakerSeeder(WineContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            AddNewWineMaker(new WineMaker { WineMakerId = 1, Name = "Kindson", Address="Budapest", WineBottles= new List<WineBottle>() });
            AddNewWineMaker(new WineMaker { WineMakerId = 2, Name = "Mila", Address="Hungary", WineBottles = new List<WineBottle>() });
            AddNewWineMaker(new WineMaker { WineMakerId = 3, Name = "Helen", Address="Vaci ut. 23", WineBottles = new List<WineBottle>() });
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNewWineMaker(WineMaker wineMaker)
        {
            var existingType = _context.WineMaker.FirstOrDefault(w => w.WineMakerId == wineMaker.WineMakerId);
            if (existingType == null)
            {
                _context.WineMaker.Add(wineMaker);
            }
        }
    }
}
