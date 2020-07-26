using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Admin.Dao;
using Web2020Project.Dao;
using Web2020Project.Models.MODEL;

namespace Web2020Project.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET
        public ActionResult Index_Admin()
        {
            return View();
        }
        public ActionResult Account_Manage()
        {
            return View();
        }
        public ActionResult Account_Update()
        {
            return View();
        }
        public ActionResult Comment_Manage()
        {
            List<BinhLuan> listComment = BinhLuanDao.getListComment();
            return View(listComment);
        }
        public ActionResult Comment_Update()
        {
            return View();
        }
        public ActionResult Member()
        {
            return View();
        }
        public ActionResult Member_Update()
        {
            return View();
        }
        public ActionResult News_Manage()
        {
            List<TinTuc> listNews = TinTucDao.getListNews();
            return View(listNews);
        }
        public ActionResult News_Update()
        {
            return View();
        }
        public ActionResult Order_Manage()
        {
            return View();
        }
        public ActionResult Producer()
        {
            List<NhaCungCap> listProducer = NhaCungCapDao.getListProducer();
            return View(listProducer);
        }
        public ActionResult Producer_Update()
        {
            return View();
        }
        public ActionResult Product_Manage()
        {
            List<SanPham> listProduct = SanPhamDao.getListProduct();
            return View(listProduct);
        }
        public ActionResult Product_Update()
        {
            return View();
        } public ActionResult Revenue()
        {
            return View();
        }
        
        
    }

}