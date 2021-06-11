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

        public DbSet<WineAPI.Models.WineMaker> WineMaker { get; set; }

        public DbSet<WineAPI.Models.WineBottle> WineBottle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
}
