using System.Web;
using System.Web.Mvc;

namespace SaaS__Chart__Builder__App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
