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
        public const string USER_TABLE = "THANHVIEN";
        public const string USER_AC = "TAIKHOAN";
        public const string USER_EMAIL = "EMAIL";

        public const string PRODUCT_TABLE = "SANPHAM";
        public const string PRODUCT_NAME = "TENSANPHAM";
        public const string ID_PRODUCT = "MASANPHAM";

        public const string PRODUCER_TABLE = "NHACUNGCAP";
        public const string ID_PRODUCER = "MANHACUNGCAP";
        public const string NAME_PRODUCER = "TENNHACUNGCAP";

        public const string NEWS_TABLE = "TINTUC";
        public const string ID_NEWS = "ID";

        public const string COMMENT_TABLE = "BINHLUAN";

        public const string ID_COMMENT = "ID";
        // GET

        #region Index

        public ActionResult Index_Admin()
        {
            ViewBag.Title = "Thống kê";
            return View();
        }

        #endregion

        #region Account

        public ActionResult Account_Manage()
        {
            ViewBag.Title = "Quản lí tài khoản";
            List<Member> members = MemberDAO.LoadMember();
            return View(members);
        }

        [ActionName("Account_Delete")] // Này phải đặt tên chớ nó trùng tên method(dòng 23), Xóa member thâu
        public ActionResult Account_Manage(string userName)
        {
            if (RemoveObj.Remove(USER_TABLE, USER_AC, userName, false))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("Account_Manage");
        }

        [HttpGet] //Phần này dùng để lấy ra đối tượng member để gán giá trị trong form update member nè
        public ActionResult Account_Update(string userName)
        {
            ViewBag.Title = "Cập nhật tài khoản";
            Member member = MemberDAO.GetMember(userName);
            return View(member);
        }

        [HttpPost] //Phần này thêm, sửa thành viên nè
        public ActionResult Account_Manage(Member member)
        {
            if (ModelState.IsValid)
            {
                string action = Request["action"];
                if (action.Equals("edit"))
                {
                    string email_temp = Request["email_temp"];
                    if (!email_temp.Equals(member.Email) &&
                        CheckObjExists.IsExist(USER_TABLE, USER_EMAIL, member.Email))
                    {
                        Session.Add("dia-log", "errThất Bại! Email " + member.Email + " đã tồn tại.");
                    }
                    else if (MemberDAO.EditMember(member))
                    {
                        Session.Add("dia-log", "sucSửa Thành Công");
                    }
                }
                else if (action.Equals("add"))
                {
                    if (!CheckObjExists.IsExist(USER_TABLE, USER_AC, member.UserName) &&
                        !CheckObjExists.IsExist(USER_TABLE, USER_EMAIL, member.Email))
                    {
                        if (MemberDAO.AddMember(member))
                        {
                            Session.Add("dia-log", "sucThêm mới tài khoản thành Công");
                        }
                    }
                    else
                    {
                        Session.Add("member", member);
                        if (CheckObjExists.IsExist(USER_TABLE, USER_AC, member.UserName))
                        {
                            Session.Add("dia-log", "errThất Bại! Tài khoản " + member.UserName + " đã tồn tại.");
                        }
                        else
                            Session.Add("dia-log", "errThất Bại! Email " + member.Email + " đã tồn tại.");
                    }
                }
            }

            return RedirectToAction("Account_Manage");
        }

        #endregion

        #region Comment

        public ActionResult Comment_Manage()
        {
            ViewBag.Title = "Quản lí bình luận";
            List<Comment> listComment = CommentDAO.LoadComment();
            return View(listComment);
        }

        public ActionResult Comment_Update()
        {
            return View();
        }

        [ActionName("Delete_Comment")]
        public ActionResult Comment_Manage(string id)
        {
            if (RemoveObj.Remove(COMMENT_TABLE, ID_COMMENT, id, true))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("Comment_Manage");
        }

        #endregion

        #region Member

        public ActionResult Member()
        {
            ViewBag.Title = "Thành Viên";
            return View();
        }

        public ActionResult Member_Update()
        {
            return View();
        }

        #endregion

        #region News

        public ActionResult News_Manage()
        {
            ViewBag.Title = "Quản lí tin tức";
            List<News> listNews = NewsDAO.loadNews();
            return View(listNews);
        }

        [ActionName("Delete_News")]
        public ActionResult News_Manage(string newsID)
        {
            if (RemoveObj.Remove(NEWS_TABLE, ID_NEWS, newsID, true))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("News_Manage");
        }

        [HttpGet] //Phần này dùng để lấy ra đối tượng member để gán giá trị trong form update member nè
        public ActionResult News_Update(string newsID)
        {
            ViewBag.Title = "Cập nhật tin tức";
            News news = NewsDAO.FindByID(newsID);
            return View(news);
        }

        [HttpPost] //Phần này thêm, sửa thành viên nè
        public ActionResult News_Manage(News news)
        {
            if (ModelState.IsValid)
            {
                string action = Request["action"];
                string id = Request["id"];
                if (action.Equals("edit"))
                {
                    news.NewsId = Int32.Parse(id);
                    if (NewsDAO.EditNews(news))

                        Console.WriteLine(news.Title + "123213213");
                    Session.Add("dia-log", "sucSửa Thành Công");
                }
                else if (action.Equals("add"))
                {
                    if (NewsDAO.AddNews(news))
                    {
                        Session.Add("dia-log", "sucThêm mới tài khoản thành Công");
                    }
                }
            }

            return RedirectToAction("News_Manage");
        }

        #endregion

        #region Order

        public ActionResult Order_Manage()
        {
            ViewBag.Title = "Quản lí đơn hàng";
            return View();
        }

        #endregion

        #region Producer

        public ActionResult Producer()
        {
            ViewBag.Title = "Nhà cung cấp";
            List<Producer> listProducer = ProducerDAO.LoadProducer();
            return View(listProducer);
        }

        [ActionName("Producer_Delete")]
        public ActionResult Producer_Manage(string ProducerID)
        {
            if (RemoveObj.Remove(PRODUCER_TABLE, ID_PRODUCER, ProducerID, false))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("Producer");
        }

        [HttpGet] //Phần này dùng để lấy ra đối tượng member để gán giá trị trong form update member nè
        public ActionResult Producer_Update(string ProducerID)
        {
            ViewBag.Title = "Cập nhật nhà cung cấp";
            Producer producer = ProducerDAO.GetProducer(ProducerID);
            return View(producer);
        }

        [HttpPost] //Phần này thêm, sửa thành viên nè
        public ActionResult Producer_Update(Producer producer)
        {
            if (ModelState.IsValid)
            {
                string action = Request["action"];
                if (action.Equals("edit"))
                {
                    string producerID_temp = Request["producerID_temp"];
                    string producerName_temp = Request["producerID_temp"];
                    if (!producerID_temp.Equals(producer.ProducerId) &&
                        CheckObjExists.IsExist(PRODUCER_TABLE, ID_PRODUCER, producer.ProducerId))
                    {
                        Session.Add("dia-log", "errThất Bại! Email " + producer.ProducerId + " đã tồn tại.");
                    }
                    else if (ProducerDAO.EditProducer(producer))
                    {
                        Session.Add("dia-log", "sucSửa Thành Công");
                    }

                    // if (!producerID_temp.Equals(producer.ProducerId) && !producerName_temp.Equals(producer.ProducerName)
                    //                                                  && CheckObjExists.IsExist(PRODUCER_TABLE, ID_PRODUCER, producer.ProducerId)
                    //                                                  && CheckObjExists.IsExist(PRODUCER_TABLE, NAME_PRODUCER, producer.ProducerName))
                    // {
                    //     Session.Add("dia-log", "errThất Bại! Email " + producer.ProducerId +" và " + producer.ProducerName + " đã tồn tại.");
                    // }
                    // else if (ProducerDAO.EditNewID(producer, producer.ProducerId))
                    // {
                    //     Session.Add("dia-log", "sucSửa Thành Công");
                    // }
                }

                else if (action.Equals("add"))
                {
                    if (!CheckObjExists.IsExist(PRODUCER_TABLE, ID_PRODUCER, producer.ProducerId))
                    {
                        if (ProducerDAO.AddProducer(producer))
                        {
                            Session.Add("dia-log", "sucThêm mới tài khoản thành Công");
                        }
                    }
                    else
                    {
                        Session.Add("producer", producer);
                        if (CheckObjExists.IsExist(PRODUCER_TABLE, ID_PRODUCER, producer.ProducerId))
                        {
                            Session.Add("dia-log", "errThất Bại! Tài khoản " + producer.ProducerId + " đã tồn tại.");
                        }
                    }
                }
            }

            return RedirectToAction("Producer");
        }

        public ActionResult Producer_Update()
        {
            return View();
        }

        #endregion

        #region Product

        public ActionResult Product_Manage()
        {
            ViewBag.Title = "Quản lí sản phẩm";
            ViewBag.ListProducer = ProducerDAO.LoadProducer();
            List<Product> listProducts = ProductsDAO.LoadProducts();
            return View(listProducts);
        }

        [ActionName("Product_Delete")]
        public ActionResult Product_Manage(string IDProduct)
        {
            //
            if (RemoveObj.Remove(PRODUCT_TABLE, ID_PRODUCT, IDProduct, true))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("Product_Manage");
        }

        [HttpGet] //Phần này dùng để lấy ra đối tượng member để gán giá trị trong form update member nè
        public ActionResult Product_Update(string productID)
        {
            ViewBag.Title = "Cập nhật sản phẩm";
            ViewBag.ListProducer = ProducerDAO.LoadProducer();
            ProductDetail productDetail = ProductsDAO.LoadProductDetail(productID);
            return View(productDetail);
        }

        [HttpPost] //Phần này thêm, sửa thành viên nè
        public ActionResult Product_Update(string productName, string producer, string salePrice, string price,
            string kind, string amount, string picture, string status, string gift, string screen,
            string operatingSystem, string CPU, string RAM, string CAMERA, string PIN)
        {
            if (ModelState.IsValid)
            {
                string action = Request["action"];
                string productID = Request["productID"];
                int id = 0;
                if (productID != null)
                {
                    id = Int32.Parse(productID);
                }

                Product product = new Product(id, productName, producer, Double.Parse(salePrice), Double.Parse(price),
                    picture, Int32.Parse(amount), Int32.Parse(status), Int32.Parse(kind));
                Technical technical = new Technical(screen, operatingSystem, CPU, RAM, CAMERA, PIN);
                ProductDetail productDetail = new ProductDetail(product, gift, technical);
                if (action.Equals("edit"))
                {
                    string productName_tmp = Request["productName"];
                    if (!productName_tmp.Equals(productDetail.Product.ProductName) &&
                        CheckObjExists.IsExist(PRODUCT_TABLE, PRODUCT_NAME, productDetail.Product.ProductName))
                    {
                        Session.Add("dia-log",
                            "errThất Bại! Email " + productDetail.Product.ProductName + " đã tồn tại.");
                    }
                    else if (ProductsDAO.EditProduct(productDetail))
                    {
                        Session.Add("dia-log", "sucSửa Thành Công");
                    }
                }
                else if (action.Equals("add"))
                {
                    if (!CheckObjExists.IsExist(PRODUCT_TABLE, PRODUCT_NAME, productDetail.Product.ProductName))
                    {
                        if (ProductsDAO.add(productDetail))
                        {
                            Session.Add("dia-log", "sucThêm mới sản phẩm thành Công");
                        }
                    }
                    else
                    {
                        Session.Add("productDetail", productDetail);
                        if (CheckObjExists.IsExist(PRODUCT_TABLE, PRODUCT_NAME, productDetail.Product.ProductName))
                        {
                            Session.Add("dia-log",
                                "errThất Bại! Sản phẩm " + productDetail.Product.ProductName + " đã tồn tại.");
                        }
                    }
                }
            }

            return RedirectToAction("Product_Manage");

            #endregion

            // #region Revenue
            //
            // public ActionResult Revenue()
            // {
            //     return View();
            // }

            // #endregion
            // }
        }
    }
}