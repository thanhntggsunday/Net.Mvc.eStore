using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Class;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IContactService<ContactDto> _contactService;

        public ContactController(IContactService<ContactDto> contactService)
        {
            _contactService = contactService;
        }

        // GET: Admin/Contact
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<ContactDto>();
            TransactionalInformation transactional;
            try
            {
                viewModel.Data = _contactService.GetAll(CultureName, out transactional);
                viewModel.Transactional = transactional;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var viewModel = new ApiResult<ContactDto>(new ContactDto());

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ApiResult<ContactDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.LanguageCode = CultureName;
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _contactService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    viewModel.ReturnStatus = true;

                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }


                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                _logger.Error(ex);
                HandleException(ex);
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            var viewModel = new ApiResult<ContactDto>();

            try
            {
                viewModel.ResultObj = _contactService.GetItemByID(id, out TransactionalInformation transaction);

                if (viewModel.ResultObj.Status != null)
                {
                    viewModel.ResultObj.StatusBoolable.Value = viewModel.ResultObj.Status.Value;
                }

                viewModel.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                _logger.Error(ex);
                HandleException(ex);
            }

            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ApiResult<ContactDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _contactService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
                    viewModel.ReturnStatus = true;

                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }


                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                _logger.Error(ex);
                HandleException(ex);
            }

            return View(viewModel);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            string message = string.Empty;
            var dto = new ContactDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _contactService.Delete(dto, out TransactionalInformation transaction);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
            }
            return RedirectToAction("Index");
        }
    }
}