using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCategoryDto : EntityBaseDto
    {
        public ProductCategoryDto()
        {
            StatusBoolable = new BooleanDto();
        }
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

       
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Images { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        public int? Order { get; set; }

        public long? ParentID { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Display(Name = "Trạng thái")]
        public BooleanDto StatusBoolable { get; set; }

     
    }
}