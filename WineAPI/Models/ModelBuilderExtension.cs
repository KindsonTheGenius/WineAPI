using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineAPI.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WineBottle>()
                .HasOne(x => x.WineMaker)
                .WithMany(x => x.WineBottles);

            var wineMaker1 = new WineMaker
            {
                WineMakerId = 1,
                Name = "Kindson Munonye",
                Address = "Budapest utca 45"
            };

            modelBuilder.Entity<WineMaker>().HasData(wineMaker1);

            modelBuilder.Entity<WineBottle>().HasData(
                new WineBottle
                {
                    WineBottleId = 1,
                    Year = "2021",
                    Size = 34,
                    CountInCeller = 10,
                    Style = Style.dry,
                    Taste =  "sweet, plum, cigar",
                    Description = "A very nice wine",
                    FoodPairing = "A good meal",
                    Link = "my link",
                    Image = "Great",
                    WineMakerId = wineMaker1.WineMakerId
                  //  WineMaker = wineMaker1
                }
            );
        }
    }
}
