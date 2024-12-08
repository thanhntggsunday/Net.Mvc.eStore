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
    public class SystemConfigController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private ISystemService<SystemConfigDto> _systemService;

        public SystemConfigController(ISystemService<SystemConfigDto> systemService)
        {
            _systemService = systemService;
        }

        // GET: Admin/SystemConfig
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<SystemConfigDto>();

            try
            {
                viewModel.Data = _systemService.GetAll(CultureName, out TransactionalInformation transaction);
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