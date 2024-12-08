using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class CartItemDto : EntityBaseDto
    {
        public long CartItemId { get; set; }

        public string CartId { get; set; }

        public long ProductId { get; set; }

        [Display(Name = "Số lượng")]
        public int Count { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Ảnh")]
        public string ProductImage { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }
    }
}