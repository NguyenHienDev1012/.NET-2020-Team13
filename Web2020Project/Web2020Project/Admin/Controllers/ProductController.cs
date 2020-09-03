using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Admin.Dao;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Controllers.Admin
{
    public class ProductController : Controller
    {
        public const string PRODUCT_TABLE = "SANPHAM";
        public const string PRODUCT_NAME = "TENSANPHAM";

        public const string ID_PRODUCT = "MASANPHAM";
        // GET

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
                Console.WriteLine(price);
                string action = Request["action"];
                string productID = Request["productID"];
                int id = 0;
                if (productID != null)
                {
                    id = Int32.Parse(productID);
                }


                double prices = price == null || price == ".0" || price == ""? 0 : Double.Parse(price);
                double salePrices = salePrice == null || salePrice == ".0" || salePrice == "" ? 0 : Double.Parse(salePrice);
                Product product = new Product(id, productName, producer, salePrices, prices,
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
        }
    }
}