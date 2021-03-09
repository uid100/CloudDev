using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeWires.Models
{
    public class WebApp
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string SourceLoc { get; set; }
        public bool IsRunning { get; set; } = false;

        public static WebApp[] GetWebApps()
        {
            return new WebApp[] {
                new WebApp { 
                    Name = "Locate",
                    Description = "GoogleMaps integration demonstration webapp. Display the user's browser location if allowed, or IP location",
                    URL = "https://findme.azurewebsites.net",
                    SourceLoc = "https://github.com/uid100/GeoLocateWeb"
                },
                new WebApp
                {
                    Name = "RateCalculator",
                    Description = "Find and display GSA per diem rates and other user location details for contract calculations",                 
                },
                new WebApp
                {
                    Name = "Whiteboard Tech Challenge",
                },
                new WebApp
                {
                    Name = "CheckedIn",
                    Description = "Engage Distance Learning students with online prompts. Generates emailed reports and requires integration with Canvas API."
                },
            };
        }
    }
}
