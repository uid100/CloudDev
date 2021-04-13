using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using OfficeWires.Data;
using OfficeWires.Models;
using System.Threading.Tasks;
using System;

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

        public async Task<ViewResult> Index()
        {
            string u = Request.Query["u"];
            return View(await ProjectBoards.ProjectList( String.IsNullOrEmpty(u) ? "uid100" : u));
        }

        public ViewResult Index1() => View();

        public string DisplayResult(string result) => result;
    }
}
