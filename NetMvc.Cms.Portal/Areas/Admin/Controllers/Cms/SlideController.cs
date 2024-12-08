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
    public class SlideController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private ISlideService<SlideDto> _sleSlideService;
        private IGroupSlideService<GroupSlideDto> _groupSlideService;

        public SlideController(ISlideService<SlideDto> slideService, IGroupSlideService<GroupSlideDto> groupSlideService)
        {
            _sleSlideService = slideService;
            _groupSlideService = groupSlideService;
        }
        //
        // GET: /Admin/Slide/
        // [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var viewModel = new ListViewModel<SlideDto>();
            TransactionalInformation transactional;

            try
            {
                viewModel.Data = _sleSlideService.GetAll(CultureName, out transactional);
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
        // GET: /Admin/Slide/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Slide/Create

        public ActionResult Create(){
           
            var viewModel = new ApiResult<SlideDto>(new SlideDto());
           
            try
            {
                BindingGroupDropDown();
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
        // POST: /Admin/Slide/Create

        [HttpPost]
        public ActionResult Create(ApiResult<SlideDto> viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _sleSlideService.Create(viewModel.ResultObj, out TransactionalInformation transaction);

                    this.SetNotification(Resources.CmsResource.AdminCreateRecordSuccess, NotificationEnumeration.Success, true);
                    viewModel.ReturnStatus = transaction.ReturnStatus;

                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                BindingGroupDropDown();
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
        // GET: /Admin/Slide/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            var viewModel = new ApiResult<SlideDto>();

            try
            {
                viewModel.ResultObj = _sleSlideService.GetItemByID(id, out TransactionalInformation transaction);
                viewModel.ReturnStatus = true;

                if (viewModel.ResultObj.Status != null)
                {
                    viewModel.ResultObj.StatusBoolable.Value = viewModel.ResultObj.Status.Value;
                }


                BindingGroupDropDown(viewModel.ResultObj.GroupID);
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
        // POST: /Admin/Slide/Edit/5

        [HttpPost]
        public ActionResult Edit(ApiResult<SlideDto> viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ResultObj.Status = viewModel.ResultObj.StatusBoolable.Value;
                    viewModel.ResultObj.LanguageCode = CultureName;
                    _sleSlideService.Update(viewModel.ResultObj, out TransactionalInformation transaction);

                    viewModel.ReturnStatus = true;
                   
                    this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);

                BindingGroupDropDown(viewModel.ResultObj.GroupID);
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

        // POST: /Admin/Slide/Delete/5

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            string message = string.Empty;
            var dto = new SlideDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _sleSlideService.Delete(dto, out TransactionalInformation transaction);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                HandleException(ex);
            }

            return RedirectToAction("Index");
        }
        private void BindingGroupDropDown(string selectedID = null)
        {
            var groupSlides = _groupSlideService.GetAll(CultureName, out TransactionalInformation transaction);
            ViewBag.Groups = new SelectList(groupSlides, "ID", "Name", selectedID);
        }
    }
}
