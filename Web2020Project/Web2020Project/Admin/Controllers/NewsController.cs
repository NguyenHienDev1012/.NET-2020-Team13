using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Admin.Dao;
using Web2020Project.Model;
using Web2020Project.Utils;

namespace Web2020Project.Controllers.Admin
{
    public class NewsController : Controller
    {
        public const string NEWS_TABLE = "TINTUC";
        public const string ID_NEWS = "ID";

        // GET
        [ValidateInput(false)]
        public ActionResult News_Manage()
        {
            ViewBag.Title = "Quản lí tin tức";
            List<News> listNews = NewsDAO.loadNews();
            return View(listNews);
        }

        [ValidateInput(false)]
        [ActionName("Delete_News")]
        public ActionResult News_Manage(string newsID)
        {
            if (RemoveObj.Remove(NEWS_TABLE, ID_NEWS, newsID, true))
            {
                Session.Add("dia-log", "sucXóa Thành Công");
            }

            return RedirectToAction("News_Manage");
        }

        [ValidateInput(false)]
        [HttpGet] //Phần này dùng để lấy ra đối tượng member để gán giá trị trong form update member nè
        public ActionResult News_Update(string newsID)
        {
            ViewBag.Title = "Cập nhật tin tức";
            News news = NewsDAO.FindByID(newsID);
            return View(news);
        }

        [ValidateInput(false)]
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
    }
}