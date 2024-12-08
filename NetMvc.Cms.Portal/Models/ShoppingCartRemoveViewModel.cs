using NetMvc.Cms.Common;

namespace NetMvc.Cms.Portal.Models
{
    public class ShoppingCartRemoveViewModel : TransactionalInformation
    {
        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the CartTotal
        /// </summary>
        public decimal CartTotal { get; set; }

        /// <summary>
        /// Gets or sets the CartCount
        /// </summary>
        public int CartCount { get; set; }

        /// <summary>
        /// Gets or sets the ItemCount
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// Gets or sets the DeleteId
        /// </summary>
        public int DeleteId { get; set; }
    }
}
