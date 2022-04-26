using System.Web.Mvc;

namespace Web.Controllers
{
  /// <summary>
  /// Will implement custom authorization later
  /// </summary>
  public class DashboardController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
