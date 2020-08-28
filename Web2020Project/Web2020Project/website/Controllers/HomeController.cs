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
            List<News> listNews = NewsDAO.loadNews();
            List<Product> listProduct_new = CategoryDAO.findCateByKind(0);
            List<Product> listProduct_hot = CategoryDAO.findCateByKind(1);
            List<Product> listProduct_sale = CategoryDAO.findCateByKind(2);
            
            MyViewModel myViewModel= new MyViewModel();
            myViewModel.listNews = listNews;
            myViewModel.listProduct_new = listProduct_new;
            myViewModel.listProduct_sale = listProduct_sale;
            myViewModel.listProduct_hot = listProduct_hot;
            
            return View(myViewModel);
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
                        Session.Add("EmailExists",member.Email+" đã tồn tại");
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
        public ActionResult Product_Detail(string id)
        {
            
            int idProduct = Convert.ToInt32(id);
            Console.WriteLine(idProduct);
            ProductDetail p_detail = CategoryDAO.getPrDetailByID(idProduct);
            List<Comment> comments = CommentDAO.LoadCMT(idProduct);
            Console.WriteLine(comments[0].Content);
            Session.Add("listcomments",comments);
            // ListModelProductDetail listModelProductDetail= new ListModelProductDetail();
            // listModelProductDetail.Listproductdetail = p_detail;
            // listModelProductDetail.comments = comments;
            
            return View(p_detail);
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