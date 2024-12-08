using NetMvc.Cms.Common.Class;

namespace NetMvc.Cms.Common.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class SlideDto : EntityBaseDto
    {
        public SlideDto()
        {
            StatusBoolable = new BooleanDto();
        }
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string Images { get; set; }

        public int Order { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupID { get; set; }

        public BooleanDto StatusBoolable { get; set; }


    }
}