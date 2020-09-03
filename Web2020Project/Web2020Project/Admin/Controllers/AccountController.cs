using System.Collections.Generic;
using System.Web.Mvc;
using Web2020Project.Model;
using Web2020Project.Utils;
using Web2020Project.Website.Dao;

namespace Web2020Project.Controllers.Admin
{
    public class AccountController : Controller
    {
        public const string USER_TABLE = "THANHVIEN";
        public const string USER_AC = "TAIKHOAN";
        public const string USER_EMAIL = "EMAIL";
        // GET
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
    }
}