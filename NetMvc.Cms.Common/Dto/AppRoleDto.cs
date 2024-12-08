using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class AppRoleDto
    {
        public string Id { get; set; }

        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
    }
}