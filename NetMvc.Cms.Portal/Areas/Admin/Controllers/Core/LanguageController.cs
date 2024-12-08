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
    public class LanguageController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        
        private ILanguageService<LanguageDto> _languageService;

        public LanguageController(ILanguageService<LanguageDto> languageService)
        {
            _languageService = languageService;
        }


        // GET: Admin/Language
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<LanguageDto>();

            try
            {
                viewModel.Data = _languageService.GetAll(CultureName, out TransactionalInformation transaction);
                viewModel.Transactional = transaction;
            }
            catch (Exception ex)
            {
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
                logger.Error(ex.ToString());
            }

            return View(viewModel);
        }

        //
        // GET: /Admin/Language/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var viewModel = new ApiResult<LanguageDto>(new LanguageDto());

            return View(viewModel);
        }

        //
        // POST: /Admin/Language/Create

        [HttpPost]
        public ActionResult Create(ApiResult<LanguageDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                    _languageService.Create(viewModel.ResultObj, out TransactionalInformation transaction);

                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        //
        // GET: /Admin/Language/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string id)
        {
            var viewModel = new ApiResult<LanguageDto>(new LanguageDto());
           
            try
            {
                var language = _languageService.GetItemByID(id, out TransactionalInformation transaction);
                viewModel.ResultObj = language;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        //
        // POST: /Admin/Language/Edit/5

        [HttpPost]
        public ActionResult Edit(LanguageDto language)
        {
            var viewModel = new ApiResult<LanguageDto>(new LanguageDto());

            try
            {
                if (ModelState.IsValid)
                {
                    language.ModifiedDate = DateTime.Now;
                    language.ModifiedBy = User.Identity.Name;
                   _languageService.Update(language, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                viewModel.ResultObj = language;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);

            }

            return View(viewModel);
        }


        //
        // POST: /Admin/Language/Delete/5

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    var dto = new LanguageDto();
                    dto.ID = id;

                    _languageService.Delete(dto, out TransactionalInformation transaction);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                HandleException(ex);
            }
            return RedirectToAction("Index");
        }
    }
}
