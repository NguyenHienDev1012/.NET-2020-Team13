using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web2020Project.Dao;
using Web2020Project.Model;
using Web2020Project.Utils;
using Web2020Project.Website.Dao;

namespace Web2020Project.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Logout()
        {
            Session.Remove("memberLogin");
            return View("Index");
        }
        
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (ModelState.IsValid)
            {
                Member member = LoginDao.checkLogin(userName, password);
                if (member != null)
                {
                    Session.Add("memberLogin",member);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session.Add("errLogin","Tên tài khoản hoặc mật khẩu không đúng");
                    return  RedirectToAction("Login", "Home");
                }
            }
            return  RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult Register(Member member)
        {
            if (ModelState.IsValid)
            {
                if (CheckObjExists.IsExist("thanhvien", "taikhoan", member.UserName) ||
                    CheckObjExists.IsExist("thanhvien", "email", member.Email))
                {
                    if (CheckObjExists.IsExist("thanhvien", "taikhoan", member.UserName))
                    {
                        Session.Add("UserExists","Tài khoản "+member.UserName+" đã tồn tại");
                    }
                    else
                    {
                        Session.Add("EmailExists","Email "+member.Email+" đã tồn tại");
                    }
                    Session.Add("memberRegister", member);
                    return RedirectToAction("Register");
                }
                else
                {
                    MemberDAO.AddMember(member);
                    return RedirectToAction("Index", "Home");
                }
               
            }
            else
            {
                return RedirectToAction("Register");
            }
                    
           
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
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