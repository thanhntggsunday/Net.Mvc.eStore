using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class AppUserRolesDto
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}