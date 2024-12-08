namespace NetMvc.Cms.Common.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductDto : EntityBaseDto
    {
        public ProductDto()
        {
            Category = new ProductCategoryDto();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

       
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [Column(TypeName = "xml")]
        [Display(Name = "Ảnh")]
        public string Images { get; set; }
        
        public decimal? Price { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

      
        public long CategoryID { get; set; }

        [Display(Name = "Số lượt xem")]
        public int ViewCount { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        public DateTime? UpTopNew { get; set; }

        public DateTime? UpTopHot { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        public ProductCategoryDto Category { get; set; }
    }
}