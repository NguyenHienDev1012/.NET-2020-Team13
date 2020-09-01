using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Web2020Project.Controllers.Admin;
using Web2020Project.Dao;
using Web2020Project.DAO;
using Web2020Project.Model;
using Web2020Project.Utils;
using Web2020Project.Website.Dao;
using Web2020Project.Website.Model;


namespace Web2020Project.Controllers
{
    public class HomeController : PhoneController
    {
        public HomeController()
        {
            this.level = 0;
        }

        public ActionResult Index()
        {
            List<News> listNews = NewsDAO.loadNews();
            List<Product> listProduct_new = CategoryDAO.findCateByKind(0);
            List<Product> listProduct_hot = CategoryDAO.findCateByKind(1);
            List<Product> listProduct_sale = CategoryDAO.findCateByKind(2);

            MyViewModel myViewModel = new MyViewModel();
            myViewModel.listNews = listNews;
            myViewModel.listProduct_new = listProduct_new;
            myViewModel.listProduct_sale = listProduct_sale;
            myViewModel.listProduct_hot = listProduct_hot;

            return View(myViewModel);
        }


        public ActionResult News()
        {
            List<News> listNews = NewsDAO.loadNews();
            return View(listNews);
        }

        public ActionResult New_Detail(string idNew)
        {
            News news = Web2020Project.Admin.Dao.NewsDAO.FindByID(Convert.ToInt32(idNew));
            List<News> listNews = NewsDAO.loadNews();
            Session.Add("listNews", listNews);
            return View(news);
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
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (ModelState.IsValid)
            {
                Member member = LoginDao.checkLogin(userName, password);
                if (member != null)
                {
                    member.Roles = LogDao.loadRolesByUserName(userName);
                    Console.WriteLine(member.Roles[0].Control);
                    Session.Add("memberLogin", member);
                    LogDao.INFO("Tai khoan: " + member.UserName + ", email: " + member.Email, "Action: Login => DONE");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session.Add("errLogin", "Tên tài khoản hoặc mật khẩu không đúng");
                    LogDao.FAILEDLOGIN("Tai khoan: " + userName, "Action: Login ==> FAILED");
                    return RedirectToAction("Login", "Home");
                }
            }

            return RedirectToAction("Login", "Home");
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
                        Session.Add("UserExists", "Tài khoản " + member.UserName + " đã tồn tại");
                    }
                    else
                    {
                        Session.Add("EmailExists", member.Email + " đã tồn tại");
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


        public ActionResult Product(string producer,string active)
        {
            return View();
        }

        public ActionResult Category()
        {

            string category = Request["cate"];
            string sort = Request["type"];
            string page = Request["page"];
            if (page == null || page.Equals(""))
            {
                page = "1";
            }

            try
            {
                if (category != null)
                {
                    if (sort == null)
                    {
                        Session.Add("category",
                            CategoryDAO.findCateByProducer(category, null, Convert.ToInt32(page)));
                        Session.Add("producer", category);
                        Console.WriteLine("Cate" + category +"Sort" + sort);
                        Session.Add("active", null);
                        Session.Add("countPages", CategoryDAO.countOfCate(category));
                        Session.Add("page", page);
                    }
                    else
                    {
                        Session.Add("category",
                            CategoryDAO.findCateByProducer(category, sort, Convert.ToInt32(page)));
                        Session.Add("producer", category);
                        Session.Add("active", sort);
                        Session.Add("countPages", CategoryDAO.countOfCate(category));
                        Session.Add("page", page);
                    }
                    Session.Add("follow",
                        "DienThoai?cate=" + category + (sort != null ? "&type=" + sort : ""));
                  //  request.getRequestDispatcher("/product.jsp").forward(request, response);
                }
                else
                {
                   // response.sendRedirect("/error404.jsp");
                }
            }
            catch (Exception e)
            {
                 Console.WriteLine(e.Message);
            }
             return View("Product");
        }
        public ActionResult Product_Detail(string id)
        {
            int idProduct = Convert.ToInt32(id);
            Console.WriteLine(idProduct);
            ProductDetail p_detail = CategoryDAO.getPrDetailByID(idProduct);
            List<Comment> comments = CommentDAO.LoadCMT(idProduct);
            Session.Add("listcomments", comments);
            return View(p_detail);
        }

        [HttpPost]
        public ActionResult Cart_Process()
        {
            string id = Request["id"];
            int soluong = 1;
            string update = Request["update"];
            Console.WriteLine(update + "MMMM");
            String msp;
            if (id != null)
            {
                msp = id;
                Product sp = null;
                try
                {
                    sp = ProductDAO.getProductID(Convert.ToInt32(msp.Trim()));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                if (sp != null)
                {
                    Cart gh = (Cart) Session["giohang"];
                    if (Request["soluong"] != null)
                    {
                        soluong = Convert.ToInt32(Request["soluong"]);
                        // if (soluong <= 1) soluong = 1;
                        if (gh == null)
                        {
                            gh = new Cart();
                            gh.CartStatus = 1;
                            List<Item> items = new List<Item>();
                            Item item = new Item();
                            item.Price = sp.SalePrice;
                            item.Product = sp;
                            item.Amount = soluong;
                            item.ItemId = sp.ProductId;
                            items.Add(item);
                            gh.Item = items;
                        }
                        else
                        {
                            List<Item> items = gh.Item;
                            bool check = false;

                            foreach (Item i in items)
                            {
                                if (i.Product.ProductId == sp.ProductId)
                                {
                                    if (update == null && soluong == 1)
                                    {
                                        i.Amount = (i.Amount + soluong);
                                    }
                                    else
                                    {
                                        i.Amount = soluong;
                                    }

                                    check = true;
                                }
                            }

                            if (!check)
                            {
                                Item item = new Item();
                                item.Price = sp.SalePrice;
                                item.Product = sp;
                                item.Amount = soluong;
                                item.ItemId = sp.ProductId;
                                items.Add(item);
                            }
                        }
                    }
                    else
                    {
                        //xoa 1 item ra gio hang
                        List<Item> items = gh.Item;
                        foreach (Item item in items)
                        {
                            if (item.Product.ProductId == sp.ProductId)
                            {
                                items.Remove(item);
                                break;
                            }
                        }
                    }

                    Session.Add("giohang", gh);
                    Cart gh_respone = (Cart) Session["giohang"];
                    HttpContext.Response.Write(gh_respone.TotalItem() + "-" +
                                               string.Format("{0:0,0}", gh_respone.TotalPrice()) + "đ");
                }
            }

            return null;
        }

        [HttpPost]
        public ActionResult CommentUser()
        {
            Comment comment = new Comment();
            string content = Request["content"];
            comment.Content = content;
            comment.Name = Request["name"];
            comment.ProductId = Convert.ToInt32(Request["productID"]);
            comment.Product = Request["product"];


            if (comment.Content.Length != 0 && comment.Name != null && comment.ProductId != null &&
                comment.Product != null)

            {
                bool result = CommentDAO.InsertCMT(comment);
                if (result)
                {
                    ProductDetail p_detail = CategoryDAO.getPrDetailByID(comment.ProductId);
                    List<Comment> comments = CommentDAO.LoadCMT(comment.ProductId);
                    Session.Add("listcomments", comments);

                    return RedirectToAction("Product_Detail", new RouteValueDictionary(
                        new
                        {
                            controller = "Home", action = "Product_Detail", Id = comment.ProductId, Model = "p_detail"
                        }));
                }
            }

            Session.Add("messagecomment", "Nội dung không được bỏ trống");
            return RedirectToAction("Product_Detail", new RouteValueDictionary(
                new {controller = "Home", action = "Product_Detail", Id = comment.ProductId, Model = "p_detail"}));
        }

        public ActionResult SearchKey(string key)
        {
            if (key != null)
            {
                try
                {
                    List<ProductDetail> dsct_sp = SearchDAO.SearchKey(key);
                    Session.Add("category", dsct_sp);
                    int count_sear = 0;
                    if (dsct_sp != null)
                    {
                        count_sear = dsct_sp.Count;
                    }

                    Session.Add("count_sear", count_sear);
                    Session.Add("key", key);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                string input = Request["input"];
                StringBuilder resp = new StringBuilder();
                String giaBan;
                if (input != null && !input.Equals(""))
                {
                    try
                    {
                        List<Product> dssp = SearchDAO.Search(input);
                        if (dssp != null)
                        {
                            foreach (Product sp in dssp)
                            {
                                if (sp.SalePrice != 0)
                                {
                                    giaBan = string.Format("{0:0,0}", sp.SalePrice) + "đ";
                                }
                                else
                                {
                                    giaBan = "";
                                }

                                resp.Append("<li><a href='/chi-tiet-san-pham?id=").Append(sp.ProductId).Append("'")
                                    .Append(">").Append("<img src='").Append(sp.Picture).Append("' alt=''>")
                                    .Append("<h3>").Append(sp.ProductName).Append("</h3>")
                                    .Append("<span class='price'>").Append(string.Format("{0:0,0}", sp.Price))
                                    .Append("đ").Append("</span>").Append("<cite>").Append(giaBan).Append("</cite>")
                                    .Append("</a></li>");
                            }

                            HttpContext.Response.Write(resp);
                        }
                        else
                        {
                            HttpContext.Response.Write("empty");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    HttpContext.Response.Write("empty");
                }
            }

            return RedirectToAction("Product", "Home");
        }
        [HttpPost]
        public ActionResult Search(string key)
        {
            //string key = Request["key"];
            if (key != null)
            {
                try
                {
                    List<ProductDetail> dsct_sp = SearchDAO.SearchKey(key);
                    Session.Add("category", dsct_sp);
                    int count_sear = 0;
                    if (dsct_sp != null)
                    {
                        count_sear = dsct_sp.Count;
                    }

                    Session.Add("count_sear", count_sear);
                    Session.Add("key", key);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                string input = Request["input"];
                StringBuilder resp = new StringBuilder();
                String giaBan;
                if (input != null && !input.Equals(""))
                {
                    try
                    {
                        List<Product> dssp = SearchDAO.Search(input);
                        if (dssp != null)
                        {
                            foreach (Product sp in dssp)
                            {
                                if (sp.SalePrice != 0)
                                {
                                    giaBan = string.Format("{0:0,0}", sp.SalePrice) + "đ";
                                }
                                else
                                {
                                    giaBan = "";
                                }

                                resp.Append("<li><a href='/Home/Product_Detail?id=").Append(sp.ProductId).Append("'")
                                    .Append(">").Append("<img src='").Append("\\Content\\"+sp.Picture).Append("' alt=''>")
                                    .Append("<h3>").Append(sp.ProductName).Append("</h3>")
                                    .Append("<span class='price'>").Append(giaBan)
                                    .Append("đ").Append("</span>").Append("<cite>").Append(string.Format("{0:0,0}", sp.Price)).Append("</cite>")
                                    .Append("</a></li>");
                            }

                            HttpContext.Response.Write(resp);
                        }
                        else
                        {
                            HttpContext.Response.Write("empty");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    HttpContext.Response.Write("empty");
                }
            }

            return new EmptyResult();
        }


        public ActionResult PaymentController()
        {
            Website.Model.Cart gh = Session["giohang"] as Cart;
            Member member = Session["memberLogin"] as Member;
            if (gh != null)
            {
                if (member != null)
                {
                    gh.Member = member;
                    gh.CartId = member.UserName;
                }

                try
                {
                    if (new CartDAO().InsertCart(gh))
                    {
                        gh.Item.Clear();
                        Session.Add("giohang", gh);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return View("Cart");
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