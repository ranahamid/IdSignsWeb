using System.Web.Mvc;

namespace Web
{
    /// <summary>
    /// FilterConfig
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// RegisterGlobalFilters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}