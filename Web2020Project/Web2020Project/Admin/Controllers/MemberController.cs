using System.Web.Mvc;

namespace Web2020Project.Controllers.Admin
{
    public class MemberController : Controller
    {
        public ActionResult Member()
        {
            ViewBag.Title = "Thành Viên";
            return View();
        }

        public ActionResult Member_Update()
        {
            return View();
        }
    }
}