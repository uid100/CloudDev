using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeWires.Models
{
    [Table("WebApps")]
    public class WebApp
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string SourceLoc { get; set; }
        public bool IsRunning { get; set; } = false;
        public string ImagePath { get; set; }

        //public static WebApp[] GetWebApps()
        //{
        //    return new WebApp[] {
        //        new WebApp { 
        //            Name = "Locate",
        //            Description = "GoogleMaps integration demonstration webapp. Display the user's browser location if allowed, or IP location",
        //            URL = "https://findme.azurewebsites.net",
        //            SourceLoc = "https://github.com/uid100/GeoLocateWeb"
        //        },
        //        new WebApp
        //        {
        //            Name = "RateCalculator",
        //            Description = "Find and display GSA per diem rates and other user location details for contract calculations",                 
        //        },
        //        new WebApp
        //        {
        //            Name = "Whiteboard Tech Challenge",
        //        },
        //        new WebApp
        //        {
        //            Name = "CheckedIn",
        //            Description = "Engage Distance Learning students with online prompts. Generates emailed reports and requires integration with Canvas API."
        //        },
        //    };
        //}
    }
}
