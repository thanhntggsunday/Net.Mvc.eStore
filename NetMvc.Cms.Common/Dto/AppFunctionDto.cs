using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class AppFunctionDto : EntityBaseDto
    {
        public string ID { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        public string URL { get; set; }

        [Display(Name = "Thứ tự hiển thị")]
        public int DisplayOrder { get; set; }
        public string ParentId { get; set; }
        public string IconCss { get; set; }
    }
}