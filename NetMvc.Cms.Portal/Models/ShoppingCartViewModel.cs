using System.Collections.Generic;
using NetMvc.Cms.Common;
using NetMvc.Cms.Common.Dto;

namespace NetMvc.Cms.Portal.Models
{
    public class ShoppingCartViewModel : TransactionalInformation
    {
        /// <summary>
        /// Gets or sets the CartItems
        /// </summary>
        public List<CartItemDto> CartItems { get; set; }

        /// <summary>
        /// Gets or sets the CartTotal
        /// </summary>
        public decimal CartTotal { get; set; }
    }
}
