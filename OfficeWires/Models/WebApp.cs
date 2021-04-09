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
        public string ImgPath { get; set; }
        public bool IsRunning { get; set; } = false;
        public string ImagePath { get; set; }

    
    }
}
