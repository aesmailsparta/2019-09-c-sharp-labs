using System.Web;
using System.Web.Mvc;

namespace lab_49_MVC_users_categories_todoitems
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
