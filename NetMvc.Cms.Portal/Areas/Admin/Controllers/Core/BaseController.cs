using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Constants;
using NetMvc.Cms.Common.Interfaces;
using NetMvc.Cms.DAL;
using NetMvc.Cms.Portal.App_Code.CustomAttributes;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    // [Authorize]
    [AuthorizeUser(AccessLevel = "ADMIN")]
    public class BaseController : Controller
    {
        //logger
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private NetMvcDbContext context;

        protected string CultureName = null;
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
            logger.Error(ex);
            RedirectToAction("Index", "Error");
        }
        protected void HandleException(Exception ex)
        {
            ViewBag.Exception = ex;
            logger.Error(ex);
            RedirectToAction("Index", "Error");
        }
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {


            // Attempt to read the culture cookie from Request
            var cultureSession = Session[SystemConstants.CULTURE];
            if (cultureSession != null)
                CultureName = cultureSession.ToString();
            else
                CultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            // Validate culture name
            CultureName = CultureHelper.GetImplementedCulture(CultureName); // This is safe

            // Modify current thread's cultures           
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            //get system name from cache
            if (!Cache.IsSet(CACHE_SYSTEM_CONFIG))
            {
                context = new NetMvcDbContext();
                var configList = context.SystemConfigs.FirstOrDefault(x => x.UniqueKey == SystemConstants.SYSTEM_NAME);
                Cache.Set(CACHE_SYSTEM_CONFIG, configList.Value);
                ViewBag.SystemNameText = configList.Value;
                context.Dispose();
            }
            else
            {
                ViewBag.SystemNameText = Cache.Get(CACHE_SYSTEM_CONFIG);
            }
            //binding language dropdownlist
            context = new NetMvcDbContext();
            var languageList = context.Languages.ToList();
            var sessionLang = Session[SystemConstants.CULTURE];
            string currentLang = sessionLang == null ? string.Empty : sessionLang.ToString();
            ViewBag.Languages = new SelectList(languageList, "ID", "Name", currentLang);
            return base.BeginExecuteCore(callback, state);
        }
        /// <summary>
        /// change culture method
        /// </summary>
        /// <param name="language"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult ChangeCulture(string language, string returnUrl)
        {
            Session[SystemConstants.CULTURE] = new CultureInfo(language);
            return Redirect(returnUrl);
        }

        /// <summary>
        /// Set notification for list
        /// </summary>
        /// <param name="message"></param>
        /// <param name="notifyType"></param>
        /// <param name="autoHideNotification"></param>
        public void SetNotification(string message, NotificationEnumeration notifyType, bool autoHideNotification = true)
        {
            this.TempData["Notification"] = message;
            this.TempData["NotificationAutoHide"] = (autoHideNotification) ? "true" : "false";

            switch (notifyType)
            {
                case NotificationEnumeration.Success:
                    this.TempData["NotificationCSS"] = "alert alert-success";
                    break;
                case NotificationEnumeration.Error:
                    this.TempData["NotificationCSS"] = "alert alert-danger";
                    break;
                case NotificationEnumeration.Warning:
                    this.TempData["NotificationCSS"] = "alert alert-warning";
                    break;
            }
        }
    }
}
