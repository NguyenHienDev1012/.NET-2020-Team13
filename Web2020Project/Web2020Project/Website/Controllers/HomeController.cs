using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web2020Project.Dao;
using Web2020Project.FormInteract;
using Web2020Project.Model;
using Web2020Project.Utils;
using Web2020Project.Website.Dao;

namespace Web2020Project.Controllers
{
    public class HomeController : Controller
    {
        MemberDAO memberDao= new MemberDAO();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Guarentee()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel loginmodel)
        {
             
            Member thanhvien = LoginDao.checkLogin(loginmodel.Usrname, loginmodel.Password);
            if (thanhvien != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return  RedirectToAction("Login", "Home");
            }

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MemberModel memberModel)
        {
            bool isOK = false;
            if (isOK)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Register", "Home");
            }
           
        }
        public ActionResult New_Detail()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Product_Detail()
        {
            return View();
        }
        public ActionResult Profile_User()
        {
            return View();
        }
        public ActionResult Question()
        {
            return View();
        }
        public ActionResult Reset_Password()
        {
            return View();
        }
    }
}