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
    public class FooterController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IFooterService<FooterDto> _footerService;

        public FooterController(IFooterService<FooterDto> footerService)
        {
            _footerService = footerService;
        }

        // GET: Admin/Footer
        public ActionResult Index()
        {
            var vewModel = new ListViewModel<FooterDto>();

            try
            {
                vewModel.Data = _footerService.GetAll(CultureName, out TransactionalInformation transaction);
                vewModel.Transactional = transaction;
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                vewModel.Transactional.ReturnStatus = false;
                vewModel.Transactional.ReturnMessage.Add(e.Message);
            }

            return View(vewModel);
        }
        //
        // GET: /Admin/Footer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Footer/Create

        public ActionResult Create()
        {
            var viewModel = new ApiResult<FooterDto>(new FooterDto());

            return View(viewModel);
        }

        //
        // POST: /Admin/Footer/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ApiResult<FooterDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _footerService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    SetNotification(Resources.CmsResource.AdminInserRecordSuccess, NotificationEnumeration.Success, true);
                   
                    return RedirectToAction("Index");

                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
                SetNotification(Resources.CmsResource.AdminInserRecordInvalid, NotificationEnumeration.Error, true);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        //
        // GET: /Admin/Footer/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        [ValidateInput(false)]
        public ActionResult Edit(string id)
        {
            var viewModel = new ApiResult<FooterDto>();

            try
            {
                viewModel.ResultObj = _footerService.GetItemByID(id, out TransactionalInformation transaction);

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

        //
        // POST: /Admin/Footer/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ApiResult<FooterDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _footerService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
                    viewModel.ReturnStatus = true;
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
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

        // POST: /Admin/Footer/Delete/5

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            string message = string.Empty;
            var dto = new FooterDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _footerService.Delete(dto, out TransactionalInformation transaction);
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
