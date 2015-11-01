using System.Web;
using System.Web.Mvc;

namespace Nimbow.Samples.AspNetMvcMfa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
