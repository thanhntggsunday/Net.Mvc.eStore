using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FooterDto : EntityBaseDto
    {
        public FooterDto()
        {
            StatusBoolable = new BooleanDto();
        }

        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        [Display(Name = "Trạng thái")]
        public BooleanDto StatusBoolable { get; set; }

    }
}