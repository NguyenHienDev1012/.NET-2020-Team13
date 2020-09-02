using System;
using System.Web;
using System.Web.Mvc;
using MySqlX.XDevAPI;
using Web2020Project.Controllers.Admin;
using Web2020Project.Model;

namespace Web2020Project.Models
{
    public class MemberFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            PhoneController phoneController= filterContext.Controller as PhoneController;
            Member member = HttpContext.Current.Session["memberLogin"] as Member;
            bool isOK = false;
            if (phoneController.level == 1)
            {
                if (member != null)
                {
                    string actionName = filterContext.ActionDescriptor.ActionName;
                    string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                   
                    if (member.Level == 1)
                    {
                        foreach (Role role in member.Roles)
                        {
                            if (role.containsInRole(actionName, controllerName)) isOK = true;
                        }
                    }

                    if (isOK == false)
                    {
                        
                        HttpContext.Current.Session.Add("messageFilter","Bạn không thể thực hiện chức năng này.");
                        phoneController.HttpContext.Response.Redirect("/Admin/Index_Admin");
                    }
                    
                }

                if (isOK == false && member.Level !=1) phoneController.HttpContext.Response.Redirect("/");
            }
            
            base.OnActionExecuting(filterContext);
        }
    }
}