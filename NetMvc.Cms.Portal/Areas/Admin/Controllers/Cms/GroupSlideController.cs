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
    public class GroupSlideController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IGroupSlideService<GroupSlideDto> _groupSlideService;

        public GroupSlideController(IGroupSlideService<GroupSlideDto> groupSlideService)
        {
            _groupSlideService = groupSlideService;
        }

        //
        // GET: /Admin/GroupSlide/
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<GroupSlideDto>();
            TransactionalInformation transactional;

            try
            {
                viewModel.Data = _groupSlideService.GetAll(CultureName, out transactional);
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
        // GET: /Admin/GroupSlide/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/GroupSlide/Create

        public ActionResult Create()
        {
            var viewModel = new ApiResult<GroupSlideDto>(new GroupSlideDto());

            return View(viewModel);
        }

        //
        // POST: /Admin/GroupSlide/Create

        [HttpPost]
        public ActionResult Create(ApiResult<GroupSlideDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.CreatedBy = User.Identity.Name;
                    viewModel.ResultObj.CreatedDate = DateTime.Now;

                    _groupSlideService.Create(viewModel.ResultObj, out TransactionalInformation transaction);
                    viewModel.ReturnStatus = true;
                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
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

        //
        // GET: /Admin/GroupSlide/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(string id)
        {
            var viewModel = new ApiResult<GroupSlideDto>();

            try
            {
                viewModel.ResultObj = _groupSlideService.GetItemByID(id, out TransactionalInformation transaction);
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
        // POST: /Admin/GroupSlide/Edit/5

        [HttpPost]
        public ActionResult Edit(ApiResult<GroupSlideDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.ModifiedDate = DateTime.Now;
                    viewModel.ResultObj.ModifiedBy = User.Identity.Name;

                    _groupSlideService.Update(viewModel.ResultObj, out TransactionalInformation transaction);
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

        // POST: /Admin/GroupSlide/Delete/5

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            string message = string.Empty;
            var dto = new GroupSlideDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _groupSlideService.Delete(dto, out TransactionalInformation transaction);
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
