using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IAboutService<AboutDto> _aboutService;
        private IProductService<ProductDto> _productService;

        public AboutController(IAboutService<AboutDto> aboutService, IProductService<ProductDto> productService)
        {
            _aboutService = aboutService;
            _productService = productService;
        }

        //
        // GET: /About/

        public ActionResult Index()
        {
            var viewModel = new ListViewModel<AboutDto>();

            try
            {
                var data = _aboutService.GetAll(CultureName, out var transaction);
                viewModel.Transactional = transaction;
                viewModel.Data = data;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.Transactional.ReturnStatus = false;
                viewModel.Transactional.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }

        //
        // GET: /Admin/News/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var viewModel = new ApiResult<AboutDto>(new AboutDto());

            return View(viewModel);
        }

        //
        // POST: /Admin/News/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ApiResult<AboutDto> viewModel)
        {
            try
            {
                viewModel.ResultObj.CreatedDate = DateTime.Now;
                viewModel.ResultObj.CreatedBy = User.Identity.Name;
                viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                viewModel.ResultObj.LanguageCode = CultureName;
               
                if (ModelState.IsValid)
                {
                    _aboutService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
               
                viewModel.ReturnMessage.Add(Resources.CmsResource.ErrorCreateRecordMessage);
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
        // GET: /Admin/News/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            var viewModel = new ApiResult<AboutDto>();

            try
            {
                viewModel.ResultObj = _aboutService.GetItemByID(id, out TransactionalInformation transaction);
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
        // POST: /Admin/News/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ApiResult<AboutDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;
                    viewModel.ResultObj.MetaTitle = StringExtensions.ToUnsignString(viewModel.ResultObj.Title);
                    _aboutService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                var errors = Utils.GetErrorListFromModelState(ModelState);

                for (int i = 0; i < errors.Count(); i++)
                {
                    ModelState.AddModelError("", errors[i]);
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                this.SetNotification(Resources.CmsResource.AdminEditRecordFailed, NotificationEnumeration.Error, true);
               
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(Resources.CmsResource.ErrorCreateRecordMessage);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                HandleException(ex);
            }
            return View(viewModel);
        }

        //
        // POST: /Admin/News/Delete/5

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            string message = string.Empty;
            var dto = new AboutDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _aboutService.Delete(dto, out TransactionalInformation transaction);
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