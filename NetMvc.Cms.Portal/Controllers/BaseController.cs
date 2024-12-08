using System;
using System.Globalization;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Constants;
using NetMvc.Cms.Common.Interfaces;

namespace NetMvc.Cms.Portal.Controllers
{
    [AllowAnonymous]
    public class BaseController : Controller
    {
        //logger
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        protected string CultureName = "vi";
        private ICacheHelper Cache { get; set; }
        public const string CACHE_SYSTEM_CONFIG = "SystemConfig";

        public BaseController() : this(new CacheHelper()) { }

        public BaseController(ICacheHelper cacheHelper)
        {
            // TODO: Complete member initialization
            this.Cache = cacheHelper;
        }
        protected void HandleApplicationException(ApplicationException ex)
        {
            ViewBag.Exception = ex;
            _logger.Error(ex);
            RedirectToAction("Index", "Error");
        }
        protected void HandleException(Exception ex)
        {
            ViewBag.Exception = ex;
            _logger.Error(ex);
            RedirectToAction("Index", "Error");
        }
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            Session[SystemConstants.CULTURE] = new CultureInfo(CultureName);
           
            return base.BeginExecuteCore(callback, state);
        }
        public ActionResult ChangeCulture(string language, string returnUrl)
        {
            Session[SystemConstants.CULTURE] = new CultureInfo(language);
            return Redirect(returnUrl);
        }
    }
}