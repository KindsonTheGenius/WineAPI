using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Seeders;

namespace WineAPI.Models
{
    public static class WebHostExtensions
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<WineContext>();

                // now we have the DbContext. Run migrations
                context.Database.Migrate();

                // now that the database is up to date. Let's seed
                new WineMakerSeeder(context).Seed();

#if DEBUG
                // if we are debugging, then let's run the test data seeder
                // alternatively, check against the environment to run this seeder
                new WineBottleSeeder(context).Seed();
#endif
            }

            return host;
        }
    }
}
