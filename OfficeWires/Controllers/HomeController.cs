using Microsoft.AspNetCore.Mvc;
using OfficeWires.Models;

namespace OfficeWires.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(WebApp.GetWebApps());
        }
    }
}
