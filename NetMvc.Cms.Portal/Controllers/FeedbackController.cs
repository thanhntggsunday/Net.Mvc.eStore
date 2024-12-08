using System;
using System.Web.Mvc;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Controllers
{
    public class FeedbackController : BaseController
    {
        private IFeedbackService<FeedbackDto> _feedbackService;

        public FeedbackController(IFeedbackService<FeedbackDto> feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FeedbackDto feedback)
        {
            try
            {
                feedback.CreatedDate = DateTime.Now;
                feedback.IsReaded = false;
                feedback.Title = "Phản hồi của khách hàng";

                if (ModelState.IsValid)
                {
                    _feedbackService.Create(feedback, out TransactionalInformation transaction);
                    TempData["Notification"] = "Gửi thông tin phản hồi thành công. Xin cảm ơn";
                    return RedirectToAction("Index", "Contact");
                }

                ModelState.AddModelError("", Resources.CmsResource.ErrorCreateRecordMessage);
                ViewBag.Error = Resources.CmsResource.ErrorCreateRecordMessage;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            
            return View(feedback);
        }
    }
}