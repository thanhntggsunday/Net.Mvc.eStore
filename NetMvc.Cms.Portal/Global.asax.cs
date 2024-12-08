using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using NetMvc.Cms.Portal.App_Start;
using NetMvc.Cms.Portal.Class;

namespace NetMvc.Cms.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        protected void Application_Start()
        {
            _logger.Info("App started at " + DateTime.Now.ToString());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());

            Bootstrapper.Run();
        }
    }
}
