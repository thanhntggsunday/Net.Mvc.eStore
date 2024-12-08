using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Common.Dto
{
    public class Function_ActionDto : EntityBaseDto
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionId { get; set; }

        [Required]
        [StringLength(100)]
        public string FunctionId { get; set; }

        public virtual ActionDto ActionDto { get; set; }

        public virtual FunctionDto FunctionDto { get; set; }

        public virtual ICollection<Role_PermissionDto> Role_Permission { get; set; } = new HashSet<Role_PermissionDto>();
    }
}