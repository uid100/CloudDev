using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using OfficeWires.Data;
using OfficeWires.Models;
using System.Threading.Tasks;

namespace OfficeWires.Controllers
{
    public class HomeController : Controller
    {
        private WebAppDbContext _AppDb;
        public HomeController(WebAppDbContext context)
        {
            _AppDb = context;
        }

        public ViewResult IndexDb() => View("IndexDb", _AppDb.WebApps.OrderBy(a=>a.Name).ToArray());

        public async Task<ViewResult> Index() => View(await ProjectBoards.ProjectList());

        public ViewResult Index1() => View();

        public string DisplayResult(string result) => result;
    }
}
