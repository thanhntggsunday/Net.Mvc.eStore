using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class OrderDto : EntityBaseDto
    {
        public long ID { get; set; }
        [Display(Name = "Người đặt hàng")]
        public string CustomerName { get; set; }

        [Display(Name = "Địa chỉ")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Số ĐT")]
        public string CustomerMobile { get; set; }

        [Display(Name = "Nội dung")]
        public string CustomerMessage { get; set; }

        [Display(Name = "Phương thức thanh toán")]
        public string PaymentMethod { get; set; }

         [Display(Name = "Trạng thái đơn hàng")]
      
        public string PaymentStatus { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? Total { get; set; }
    }
}