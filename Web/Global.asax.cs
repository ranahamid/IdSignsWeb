using NLog;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebRTC.Extends.DI;

namespace Web
{
    /// <summary>
    /// MvcApplication
    /// </summary>
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Initialize(GlobalConfiguration.Configuration);
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            logger.Error(ex);
        }
    }
}