using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Portal.Areas.Admin.Class;
using NetMvc.Cms.Portal.Areas.Admin.Models;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class NavigationController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private IFunctionService<FunctionDto> _functionService;

        public NavigationController(IFunctionService<FunctionDto> functionService)
        {
            _functionService = functionService;
        }


        //
        // GET: /Admin/Navigation/
        [ChildActionOnly]
        [AllowAnonymous]
        // [OutputCache(Duration = 3600)]
        public ActionResult GetMainMenu()
        {
            List<FunctionDto> menusource = _functionService.GetAll(CultureName, out TransactionalInformation transaction);

            List<MenuViewModel> model = CreateVM(null, menusource);  // transform it into the ViewModel

            return View(model);

        }
        public List<MenuViewModel> CreateVM(string parentid, List<FunctionDto> source)
        {
            var sf = new List<FunctionDto>();

            foreach (var item in source)
            {
                // var id = item.ID;
                if (MenuConstants.AdminMenuConstants.Contains(item.ID.ToUpper()))
                {
                    sf.Add(item);
                }
            }

            var query = from men in sf
                where men.ParentID == parentid
                select new MenuViewModel()
                {
                    MenuId = men.ID,
                    Text = men.Text,
                    Link = men.Link,
                    Target = men.Target,
                    CssClass = men.CssClass,
                    Children = CreateVM(men.ID, source)
                };
            return query.ToList();
        }
    }
}
