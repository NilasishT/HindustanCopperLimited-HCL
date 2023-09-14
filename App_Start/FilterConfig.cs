using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.GlobalClass;

namespace Hindustancopperlimited
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UserRightAttribute());            
        }
    }
}