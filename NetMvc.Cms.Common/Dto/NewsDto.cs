namespace NetMvc.Cms.Common.Dto
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Globalization;

    public class NewsDto : EntityBaseDto
    {
        public NewsDto()
        {
            Category = new CategoryDto();
        }
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Images { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Display(Name = "Ngày phát hành")]
        public DateTime? PublishedDate { get; set; }

        [StringLength(50)]
        public string RelatedNewses { get; set; }

        public long CategoryID { get; set; }

        [Display(Name = "Số lượt xem")]
        public int ViewCount { get; set; }

        [StringLength(50)]
        [Display(Name = "Nguồn")]
        public string Source { get; set; }

        [Display(Name = "Top tin tức")]
        public DateTime? UpTopNew { get; set; }

        [Display(Name = "Top hot")]
        public DateTime? UpTopHot { get; set; }

        [Display(Name = "Tên danh mục tin")]
        public String CategoryName { get; set; }
        public CategoryDto Category { get; set; }

        public string StrPublishedDate
        {
            get
            {
                if (CreatedDate == null)
                {
                    return DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    return CreatedDate.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }
    }
}