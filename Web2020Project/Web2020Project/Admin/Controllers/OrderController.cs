using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Admin.Dao;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Controllers.Admin
{
    public class OrderController : Controller
    {
        public const string ORDER_TABLE = "GIOHANG";
        public const string ORDER_ID = "MAGIOHANG";
        public const string USER_EMAIL = "EMAIL";
        // GET
        public ActionResult Order_Manage()
        {
            ViewBag.Title = "Quản lí đơn hàng";
            List<CartDB> listOrder = OrderDAO.OrdersList();
            IDictionary<CartDB, List<CartDB>> orderDetail = new Dictionary<CartDB, List<CartDB>>();
            for (int i = 0; i < listOrder.Count; i++)
            {
                orderDetail.Add(listOrder[i], OrderDAO.OrdersDetailList(listOrder[i].CartId));
            }
            return View(orderDetail);
        }
        [ActionName("Delete_Order")]
        public ActionResult Order_Manage(string cartID)
        {
            ViewBag.Order = OrderDAO.GetCartDB(cartID);
            if (RemoveObj.Remove(ORDER_TABLE, ORDER_ID, cartID, false))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("Order_Manage");
        }
        // [HttpGet] //Phần này dùng để lấy ra đối tượng member để gán giá trị trong form update member nè
        // public ActionResult Order_Manage(string cartID)
        // {
        //     ViewBag.Title = "Quản lí đơn hàng";
        //
        //     return View();
        // }
    }
}