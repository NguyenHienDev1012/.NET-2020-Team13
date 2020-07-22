using System.Web.Mvc;

namespace Web2020Project.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET
        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            return View();
        }
    }
}