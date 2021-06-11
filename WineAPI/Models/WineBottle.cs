using System;
namespace WineAPI.Models
{
    public enum Styles
    {
        dry,
        sweet,
        strong
    }

    public class WineBottle
    {
        public int WineBottleId { get; set; }
        public string Year { get; set; }
        public int Size { get; set; }
        public int CountInCeller { get; set; }
        public string Style { get; set; }
        public string Taste { get; set; }
        public string Description { get; set; }
        public string FoodPairing { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public int WineMakerId { get; set; }

        public WineMaker WineMaker { get; set; }

        public WineBottle()
        {
        }

        public WineBottle(int wineBottleId, string year, int size, int countInCeller, string style, string taste, string description, string foodPairing, string link, string image, int wineMakerId, WineMaker wineMaker)
        {
            WineBottleId = wineBottleId;
            Year = year;
            Size = size;
            CountInCeller = countInCeller;
            Style = style;
            Taste = taste;
            Description = description;
            FoodPairing = foodPairing;
            Link = link;
            Image = image;
            WineMakerId = wineMakerId;
            WineMaker = wineMaker;
        }
    }
}
