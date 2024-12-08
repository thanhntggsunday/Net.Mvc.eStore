using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private IOrderBusinessService _orderBusinessService;
       
        public HomeController(IOrderBusinessService orderBusinessService)
        {
            _orderBusinessService = orderBusinessService;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.OrdersCount = _orderBusinessService.GetCount(out var transactional);

            return View();
        }
    }
}