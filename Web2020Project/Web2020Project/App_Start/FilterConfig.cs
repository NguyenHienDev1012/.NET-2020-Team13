using System.Web;
using System.Web.Mvc;
using Web2020Project.Models;

namespace Web2020Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MemberFilter());
        }
    }
}