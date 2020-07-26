using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web2020Project.Admin.Dao;
using Web2020Project.Dao;
using Web2020Project.FormInteract;
using Web2020Project.libs;
using Web2020Project.Model;
using Web2020Project.Models.MODEL;
using Web2020Project.Utils;

namespace Web2020Project.Controllers
{
    public class HomeController : Controller
    {
        ThanhVienDao thanhVienDao= new ThanhVienDao();
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
             
            ThanhVien thanhvien = LoginDao.checkLogin(loginmodel.Usrname, loginmodel.Password);
            if (thanhvien != null)
            {
                Console.WriteLine(thanhvien.HoTen);
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
        public ActionResult Register(ThanhVienModel thanhVienModel)
        {
            ThanhVien thanhvien= new ThanhVien(thanhVienModel.UsrName, thanhVienModel.Password, thanhVienModel.FullName, thanhVienModel.Gender, 
                thanhVienModel.Email, Convert.ToInt32(thanhVienModel.Sdt), thanhVienModel.Address, 0,  "" );
            bool isOK = thanhVienDao.add(thanhVienModel);
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
            List<SanPham> listProduct = SanPhamDao.getListProduct();
            // List<SanPham> listProduct = new List<SanPham>();
            // listProduct.Add(new SanPham(1, "asd", "asd", 100000, 10000000,
            //     "/Content/assets/img/products/huawei/244.jpg", 3, 2, 1));
            return View(listProduct);
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