using System.Web;
using System.Web.Mvc;
using Contoso.MVC.Filter;

namespace Contoso.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ContosoExceptionFilter()); // register it globaly
        }
    }
}
