using Microsoft.AspNetCore.Mvc;
using System.Linq;
using OfficeWires.Data;

namespace OfficeWires.Controllers
{
    public class AdminController : Controller
    {
        private WebAppDbContext _AppDb;
        public AdminController(WebAppDbContext context)
        {
            _AppDb = context;
        }

        ViewResult AppList()
        {
            return View(_AppDb.WebApps.OrderBy(a => a.Name).ToArray());
        }
    }
}
