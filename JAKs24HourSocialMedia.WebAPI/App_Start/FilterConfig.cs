using System.Web;
using System.Web.Mvc;

namespace JAKs24HourSocialMedia.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
