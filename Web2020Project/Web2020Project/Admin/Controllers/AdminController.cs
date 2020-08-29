using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
        // GET

        #region Index

        public ActionResult Index_Admin()
        {
            return View();
        }

        #endregion

        #region Account

        public ActionResult Account_Manage()
        {
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
            return View();
        }

        public ActionResult Comment_Update()
        {
            return View();
        }

        #endregion

        #region Member

        public ActionResult Member()
        {
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
            List<News> listNews = NewsDAO.LoadNews();
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
            News news = NewsDAO.FindByID(newsID);
            return View(news);
        }
        [HttpPost] //Phần này thêm, sửa thành viên nè
        public ActionResult News_Update(Member member)
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

            return RedirectToAction("News_Manage");
        }
        #endregion

        #region Order

        public ActionResult Order_Manage()
        {
            return View();
        }

        #endregion

        #region Producer

        public ActionResult Producer()
        {
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
        public ActionResult Product_Update(string IDProduct)
        {
            Product productDetail = ProductDAO.getProductID(Int32.Parse(IDProduct));
            return View();
        }

        [HttpPost] //Phần này thêm, sửa thành viên nè
        public ActionResult Product_Update(ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                string action = Request["action"];
                if (action.Equals("edit"))
                {
                    string productName_tmp = Request["productName_tmp"];
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
                            Session.Add("dia-log", "sucThêm mới tài khoản thành Công");
                        }
                    }
                    else
                    {
                        Session.Add("productDetail", productDetail);
                        if (CheckObjExists.IsExist(PRODUCT_TABLE, PRODUCT_NAME, productDetail.Product.ProductName))
                        {
                            Session.Add("dia-log",
                                "errThất Bại! Tài khoản " + productDetail.Product.ProductName + " đã tồn tại.");
                        }
                        else
                            Session.Add("dia-log",
                                "errThất Bại! Email " + productDetail.Product.ProductName + " đã tồn tại.");
                    }
                }
            }

            return RedirectToAction("Account_Manage");
        }

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