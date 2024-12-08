using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class AppActionDto : EntityBaseDto
    {
        public string Id { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
    }
}