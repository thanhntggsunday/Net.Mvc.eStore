using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using log4net;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.BL.ServiceImp;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Constants;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Common.ViewModel.Common;
using NetMvc.Cms.Portal.Models;

namespace NetMvc.Cms.Portal.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private IOrderBusinessService _orderBusinessService;

        public OrderController(IOrderBusinessService orderBusinessService)
        {
            _orderBusinessService = orderBusinessService;
        }

        //// GET: Admin/Order
        //public ActionResult Index()
        //{
        //    var viewModel = new ListViewModel<OrderDto>();
        //    TransactionalInformation transactional;

        //    try
        //    {
        //        viewModel.Data = _orderBusinessService.GetAll(out transactional);
        //        viewModel.Transactional = transactional;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error(ex.ToString());
        //        viewModel.Transactional.ReturnStatus = false;
        //        viewModel.Transactional.ReturnMessage.Add(ex.Message);
        //    }

        //    return View(viewModel);
        //}

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(long id)
        {
            var viewModel = new OrderDetailViewModel();
            TransactionalInformation transactional;

            try
            {
                viewModel.OrderItem = _orderBusinessService.GetOrder(id, out transactional, out var orderDetails);
                viewModel.OrderDetailDTOs = orderDetails;
                viewModel.ReturnStatus = transactional.ReturnStatus;
                viewModel.ReturnMessage = transactional.ReturnMessage;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }

            return View(viewModel);
        }


        // GET: Admin/Order/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            var viewModel = new OrderDetailViewModel();
            TransactionalInformation transactional;

            try
            {
                viewModel.OrderItem = _orderBusinessService.GetOrder(id, out transactional, out var orderDetails);
                viewModel.OrderDetailDTOs = orderDetails;
                viewModel.ReturnStatus = transactional.ReturnStatus;
                viewModel.ReturnMessage = transactional.ReturnMessage;

                BindingDropDownList(viewModel.OrderItem.StrStatus, viewModel.OrderItem.PaymentStatus);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
            }


            return View(viewModel);
        }

        // POST: Admin/Order/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderDetailViewModel viewModel)
        {
            try
            {
                var dto = new OrderDto();
                dto.ID = viewModel.OrderItem.ID;
                dto.PaymentStatus = viewModel.OrderItem.PaymentStatus;
                dto.StrStatus = viewModel.OrderItem.StrStatus;
                dto.ModifiedDate = DateTime.Now;
                dto.ModifiedBy = User.Identity.Name;
                _orderBusinessService.UpdateOrder(dto, out TransactionalInformation transaction);
                viewModel.ReturnStatus = true;

                this.SetNotification(Resources.CmsResource.AdminEditRecordSucess, NotificationEnumeration.Success, true);

                return RedirectToAction("Index");
            
            }
            catch (Exception ex)
            {
                viewModel.ReturnStatus = false;
                viewModel.ReturnMessage.Add(ex.Message);
                _logger.Error(ex);
                HandleException(ex);

                BindingDropDownList(viewModel.OrderItem.StrStatus, viewModel.OrderItem.PaymentStatus);
            }

            return View(viewModel);
        }

        private void BindingDropDownList(string orderStatusItem = null, string paymentStatusItem = null)
        {
            var orderStatuses = new List<SelectListItem>();
            var paymentStatuses = new List<SelectListItem>();

            orderStatuses.Add(new SelectListItem()
            {
                Value = OrderConstants.WAIT_FOR_CONFIRMATION_VI,
                Text = OrderConstants.WAIT_FOR_CONFIRMATION_VI

            });

            orderStatuses.Add(new SelectListItem()
            {
                Value = OrderConstants.DELIVERING_VI,
                Text = OrderConstants.DELIVERING_VI

            });

            orderStatuses.Add(new SelectListItem()
            {
                Value = OrderConstants.DELIVERED_VI,
                Text = OrderConstants.DELIVERED_VI

            });

            orderStatuses.Add(new SelectListItem()
            {
                Value = OrderConstants.CANCELED_VI,
                Text = OrderConstants.CANCELED_VI

            });


            paymentStatuses.Add(new SelectListItem()
            {
                Value = PaymentStatusConstants.UNPAID_VI,
                Text = PaymentStatusConstants.UNPAID_VI

            });

            paymentStatuses.Add(new SelectListItem()
            {
                Value = PaymentStatusConstants.PAID_VI,
                Text = PaymentStatusConstants.PAID_VI

            });


            paymentStatuses.Add(new SelectListItem()
            {
                Value = PaymentStatusConstants.CANCELED_VI,
                Text = PaymentStatusConstants.CANCELED_VI

            });

            ViewBag.OrderStatus = new SelectList(orderStatuses, "Value", "Text", orderStatusItem);
            ViewBag.PaymentStatus = new SelectList(paymentStatuses, "Value", "Text", paymentStatusItem);
        }


        [Route("GetAllPaging")]
        [HttpGet]
        public ActionResult GetAllPaging()
        {
            var result = new DataTableViewModel<OrderDto>();

            try
            {
                var draw = Request.Params.GetValues("draw").FirstOrDefault();
                var start = Request.Params.GetValues("start").FirstOrDefault();
                var length = Request.Params.GetValues("length").FirstOrDefault();
                var search = Request.Params.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int startIndex = start != null ? Convert.ToInt32(start) : 0;
                int intDraw = draw != null ? Convert.ToInt32(draw) : 0;

                var skipItemCount = startIndex;

                var items = _orderBusinessService.GetDataTablePaging(CultureName, skipItemCount, pageSize, out var transaction);

                result.data = items.ToArray();
                result.returnStatus = true;
                result.returnMessage.Add("OK");
                result.recordsTotal = transaction.Pager.TotalRows;
                result.recordsFiltered = transaction.Pager.TotalRows;
                result.draw = intDraw;

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                result.returnStatus = false;
                result.returnMessage.Add(ex.Message);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


    }
}
