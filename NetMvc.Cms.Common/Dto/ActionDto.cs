using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class ActionDto : EntityBaseDto
    {
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên")]
        public string Name { get; set; }


        [StringLength(100)]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
    }
}