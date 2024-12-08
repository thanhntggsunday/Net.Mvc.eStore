using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class AppAllUserPermissionDto
    {
        public string UserId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        public string FunctionId { get; set; }
        public string ActionId { get; set; }
        public string RoleId { get; set; }

        [Display(Name = "Tên role")]
        public string RoleName { get; set; }
    }
}