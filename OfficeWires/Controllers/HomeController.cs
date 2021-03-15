using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OfficeWires.Data;
using OfficeWires.Models;

namespace OfficeWires.Controllers
{
    public class HomeController : Controller
    {
        private WebAppDbContext _AppDb;
        public HomeController(WebAppDbContext context)
        {
            _AppDb = context;
        }

        public ViewResult Index() => View(_AppDb.WebApps.OrderBy(a=>a.Name).ToArray());

        public ViewResult Index1() => View();       
    }
}
