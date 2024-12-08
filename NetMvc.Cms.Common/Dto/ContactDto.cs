using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ContactDto : EntityBaseDto
    {
        public ContactDto()
        {
            StatusBoolable = new BooleanDto();
        }

        [Key]
        public int ID { get; set; }

      
        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        [Display(Name = "Trạng thái")]
        public BooleanDto StatusBoolable { get; set; }
    }
}