using log4net;
using System;
using System.Reflection;
using System.Web.Mvc;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;

namespace NetMvc.Cms.Portal.Controllers
{
    public class MenuController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IMenuService<MenuDto> _menuService;

        public MenuController(IMenuService<MenuDto> menuService)
        {
            _menuService = menuService;
        }

        //
        // GET: /Admin/Menu/
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Get menu top
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [AllowAnonymous]
        public ViewResult GetMenuTop()
        {
            var viewModel = new ListViewModel<MenuDto>();

            try
            {
                var menus = _menuService.GetTopMenuAll(CultureName, out TransactionalInformation transaction);

                viewModel.Data = menus;
                viewModel.Transactional = transaction;
            }
            catch (Exception ex)
            {
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
                logger.Error(ex.ToString());
                throw;
            }

            return View(viewModel);
        }
       
        #region Private Method
        
        #endregion
    }
}
