using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Website.Dao;
using Web2020Project.Admin.Dao;
using Web2020Project.Model;
using Web2020Project.Utils;
using Web2020Project.Website.Dao;
using NewsDAO = Web2020Project.Admin.Dao.NewsDAO;

namespace Web2020Project.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET
        public ActionResult Index_Admin()
        {
            ViewBag.Title = "Thống kê";
            return View();
        }
    }
}