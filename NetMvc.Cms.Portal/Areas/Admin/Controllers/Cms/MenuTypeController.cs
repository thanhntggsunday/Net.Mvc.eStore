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
    public class MenuTypeController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IMenuTypeService<MenuTypeDto> _menuTypeService;

        public MenuTypeController(IMenuTypeService<MenuTypeDto> menuTypeService)
        {
            _menuTypeService = menuTypeService;
        }


        // GET: Admin/MenuType
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<MenuTypeDto>();
            TransactionalInformation transactional;

            try
            {
                viewModel.Data = _menuTypeService.GetAll(CultureName, out transactional);
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
        //
        // GET: /Admin/MenuType/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/MenuType/Create

        public ActionResult Create()
        {
            var viewModel = new ApiResult<MenuTypeDto>(new MenuTypeDto());

            return View(viewModel);
        }

        //
        // POST: /Admin/MenuType/Create

        [HttpPost]
        public ActionResult Create(ApiResult<MenuTypeDto> viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedDate = DateTime.Now;
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                  
                    _menuTypeService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    viewModel.ReturnStatus = transaction.ReturnStatus;

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
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
        // GET: /Admin/MenuType/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string id)
        {

            var viewModel = new ApiResult<MenuTypeDto>();

            try
            {
                viewModel.ResultObj = _menuTypeService.GetItemByID(id, out TransactionalInformation transaction);
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
        // POST: /Admin/MenuType/Edit/5

        [HttpPost]
        public ActionResult Edit(ApiResult<MenuTypeDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;

                    _menuTypeService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
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

        // POST: /Admin/MenuType/Delete/5

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            string message = string.Empty;
            var dto = new MenuTypeDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _menuTypeService.Delete(dto, out TransactionalInformation transaction);
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
