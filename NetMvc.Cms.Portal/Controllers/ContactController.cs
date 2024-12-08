using System;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;

namespace NetMvc.Cms.Portal.Controllers
{
    public class ContactController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IContactService<ContactDto> _contactService;

        public ContactController(IContactService<ContactDto> contactService)
        {
            _contactService = contactService;
        }

        // GET: Contact
        public ActionResult Index()
        {
            var viewModel = new ApiResult<ContactDto>();

            try
            {
                var itemDto = _contactService.GetDefaultContact(CultureName, out TransactionalInformation transaction);

                viewModel.ResultObj = itemDto;
                viewModel.ReturnStatus = transaction.ReturnStatus;
               
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }
    }
}