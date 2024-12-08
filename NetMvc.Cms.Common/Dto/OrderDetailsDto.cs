using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class OrderDetailsDto : EntityBaseDto
    {
        [Display(Name = "Mã đơn hàng")]
        public long OrderID { get; set; }

        [Display(Name = "Mã sản phẩm")]
        public long ProductID { get; set; }

        [Display(Name = "Số lượng")]
        public long Quantitty { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
    }
}