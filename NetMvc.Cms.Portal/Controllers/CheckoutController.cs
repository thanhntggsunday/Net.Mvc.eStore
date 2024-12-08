using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NetMvc.Cms.BL.Interfaces;
using NetMvc.Cms.Common.Dto;
using NetMvc.Cms.Portal.Models;
using NetMvc.Cms.Portal.Models.BusinessModels;

namespace NetMvc.Cms.Portal.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        // IOderBusinessService _oderBusinessService;
        /// <summary>
        /// Defines the PromoCode
        /// </summary>
        private const string PromoCode = "FREE";

        /// <summary>
        /// Defines the _orderBusinessModel
        /// </summary>
        private CheckoutBusinessModel _orderBusinessModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutController"/> class.
        /// </summary>
        /// <param name="oderBusinessService">The oderBusinessService<see cref="IOrderBusinessService"/></param>
        public CheckoutController(IOrderBusinessService oderBusinessService)
        {
            _orderBusinessModel = new CheckoutBusinessModel(oderBusinessService);
        }

        //
        // GET: /Checkout/
        /// <summary>
        /// The AddressAndPayment
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [Authorize]
        public ActionResult AddressAndPayment()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            try
            {
                var cartItems = (List<CartItemDto>)Session["CartItems"];
                var cartTotal = (decimal)Session["CartTotal"];
                orderViewModel.CartItems = cartItems;
                orderViewModel.CartTotal = cartTotal;
            }
            catch (Exception)
            {
                orderViewModel.CartItems = new List<CartItemDto>();
                orderViewModel.CartTotal = 0;

                return View(orderViewModel);
            }



            return View(orderViewModel);
        }

        //
        // POST: /Checkout/AddressAndPayment
        /// <summary>
        /// The AddressAndPayment
        /// </summary>
        /// <param name="orderViewModel">The orderViewModel<see cref="OrderViewModel"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [Authorize]
        [HttpPost]
        public ActionResult AddressAndPayment(OrderViewModel orderViewModel)
        {
            try
            {
                orderViewModel.PromoCode = "FREE";
                orderViewModel.PaymentMethod = "Thanh toán khi nhận hàng";

                var orderId = _orderBusinessModel.AddressAndPayment(orderViewModel, this.HttpContext);

                // Reset Session:
                Session["CartItems"] = null;
                Session["CartTotal"] = null;

                return RedirectToAction("Complete", "Checkout", new { result = orderId });
            }
            catch (Exception ex)
            {
                //Invalid - redisplay with errors
                return View(orderViewModel);
            }
        }

        //
        // GET: /Checkout/Complete
        /// <summary>
        /// The Complete
        /// </summary>
        /// <param name="result">The result<see cref="object"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [Authorize]
        public ActionResult Complete(int result)
        {
            // Validate customer owns this order

            OrderViewModel orderViewModel = new OrderViewModel() { ID = result };


            return View("Complete", orderViewModel);
        }
    }
}
