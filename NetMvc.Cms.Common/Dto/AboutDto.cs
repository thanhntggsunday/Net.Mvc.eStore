using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Common.Dto
{
    public class AboutDto : EntityBaseDto
    {
        public AboutDto()
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

        [Display(Name = "Trạng thái")]
        public BooleanDto StatusBoolable { get; set; }


    }
}