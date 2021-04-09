using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using OfficeWires.Models;

namespace OfficeWires.Data
{
    public static class SeedData
    {
        public static void DbInit(IApplicationBuilder app)
        {
            WebAppDbContext context = app.ApplicationServices.CreateScope()
                        .ServiceProvider.GetRequiredService<WebAppDbContext>();

            context.Database.EnsureCreated();
            if (context.WebApps.Any()) return;

            var apps = new WebApp[] {
                new WebApp
                {
                    Name = "OfficeWires",
                    Description = ""
                },
                new WebApp {
                    Name = "Locate",
                    Description = "GoogleMaps integration demonstration webapp. Display the user's browser location if allowed, or IP location",
                    URL = "https://findme.azurewebsites.net",
                    SourceLoc = "https://github.com/uid100/GeoLocateWeb",
                    ImagePath = "~/images/Map3.png"
                },
                new WebApp
                {
                    Name = "RateCalculator",
                    Description = "Find and display GSA per diem rates and other user location details for contract calculations",
                    ImagePath = "~/images/currencycalculator.png"
                },
                new WebApp
                {
                    Name = "Miscellaneous",
                    ImagePath = "~/images/sketch.png"
                },
                new WebApp
                {
                    Name = "CheckedIn",
                    Description = "Engage Distance Learning students with online prompts. Generates emailed reports and requires integration with Canvas API.",
                    ImagePath = "~/images/sketch.png"
                },
            };

            foreach (WebApp a in apps) context.WebApps.Add(a);
            context.SaveChanges();
        }
    }
}
