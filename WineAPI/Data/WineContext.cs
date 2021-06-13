using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WineAPI.Models;

    public class WineContext : DbContext
    {

        public WineContext (DbContextOptions<WineContext> options)
            : base(options)
        {
        }
        public DbSet<WineMaker> WineMaker { get; set; }
        public DbSet<WineBottle> WineBottle { get; set; }
        public DbSet<WineImage> WineImage { get; set; }

}
