using System.ComponentModel.DataAnnotations;

namespace ComNetMvc.Cms.Commonmon.Dto
{
    public class AppLevelPermissionDto
    {
        public int FunctionActionId { get; set; }
        public string FunctionId { get; set; }

        [Display(Name = "Tên chức năng")]
        public string FunctionName { get; set; }
        public string ActionId { get; set; }

        [Display(Name = "Tên action")]
        public string ActionName { get; set; }
    }
}