using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Model;
using Web2020Project.Utils;
using Web2020Project.Website.Dao;

namespace Web2020Project.Controllers.Admin
{
    public class CommentController : Controller
    {
        public const string ID_COMMENT = "ID";

        public const string COMMENT_TABLE = "BINHLUAN";


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
    }
}