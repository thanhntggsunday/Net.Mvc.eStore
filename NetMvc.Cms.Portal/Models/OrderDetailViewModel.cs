using System;
using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    /// <summary>
    /// Defines the <see cref="OrderDetailViewModel" />
    /// </summary>
    public class OrderDetailViewModel : TransactionalInformation
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the CustomerAddress
        /// </summary>
        public string CustomerAddress { get; set; }

        /// <summary>
        /// Gets or sets the CustomerEmail
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the CustomerMobile
        /// </summary>
        public string CustomerMobile { get; set; }

        /// <summary>
        /// Gets or sets the CustomerMessage
        /// </summary>
        public string CustomerMessage { get; set; }

        /// <summary>
        /// Gets or sets the PaymentMethod
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the PaymentStatus
        /// </summary>
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Status
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or sets the TotalPrice
        /// </summary>
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the PromoCode
        /// </summary>
        public string PromoCode { get; set; }
      
        /// <summary>
        /// Gets or sets the CartTotal
        /// </summary>
        public decimal CartTotal { get; set; }

        public string StrStatus { get; set; }

        public OrderDto OrderItem { get; set; }

        /// <summary>
        /// Gets or sets the OrderDetailDTOs
        /// </summary>
        public List<OrderDetailsDto> OrderDetailDTOs { get; set; }
    }
}
