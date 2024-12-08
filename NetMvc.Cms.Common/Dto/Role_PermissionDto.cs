using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class Role_PermissionDto : EntityBaseDto
    {
        public int ID { get; set; }

        public int Function_ActionID { get; set; }

        [Required]
        [StringLength(128)]
        public string AppRoleId { get; set; }

        public virtual AppRoleDto AppRoleDto { get; set; }

        // public virtual Function_ActionDto Function_Action { get; set; }
    }
}