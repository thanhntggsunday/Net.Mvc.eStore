using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IFeedbackService<FeedbackDto> _feedbackService;

        public FeedbackController(IFeedbackService<FeedbackDto> feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public ActionResult Index()
        {
            var vewModel = new ListViewModel<FeedbackDto>();

            vewModel.Data = _feedbackService.GetAll(CultureName, out TransactionalInformation transaction);

            return View(vewModel);
        }

        //
        // GET: /Admin/Feedback/Details/5

        public ActionResult Details(long id)
        {
            var viewModel = new ApiResult<FeedbackDto>();

            try
            {
                viewModel.ResultObj = _feedbackService.GetItemByID(id, out TransactionalInformation transaction);
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

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            string message = string.Empty;
            var dto = new FeedbackDto();
            dto.ID = id;

            try
            {
                if (ModelState.IsValid)
                {
                    _feedbackService.Delete(dto, out TransactionalInformation transaction);
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