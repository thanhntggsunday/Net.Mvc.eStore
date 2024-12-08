using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMvc.Cms.Common.Constants
{
    public class OrderConstants
    {
        public const string WAIT_FOR_CONFIRMATION_VI = "Chờ xác nhận";
        public const string DELIVERING_VI = "Đang giao";
        public const string DELIVERED_VI = "Đã giao thành công";
        public const string CANCELED_VI = "Đã hủy";
    }

    //PaymentStatus

    public class PaymentStatusConstants
    {
        public const string UNPAID_VI = "Chưa thanh toán";
        public const string PAID_VI = "Đã thanh toán";
        public const string CANCELED_VI = "Đã hủy";
    }
}
