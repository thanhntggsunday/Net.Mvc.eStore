using System;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        
        private IUserService<AppUserDto> _userService;

        public UserController(IUserService<AppUserDto> userService)
        {
            _userService = userService;
        }


        // GET: Admin/User
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<AppUserDto>();

            try
            {
                viewModel.Data = _userService.GetAll(CultureName, out TransactionalInformation transaction);
                viewModel.Transactional = transaction;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.ToString());

            }

            return View(viewModel);
        }
    }
}