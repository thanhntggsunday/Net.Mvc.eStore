using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Model.Entities
{
    public partial class Function_Action : EntityBase
    {
        public Function_Action()
        {
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionId { get; set; }

        [Required]
        [StringLength(100)]
        public string FunctionId { get; set; }

        public virtual Action Action { get; set; }

        public virtual Function Function { get; set; }

        public virtual ICollection<Role_Permission> Role_Permission { get; set; } = new HashSet<Role_Permission>();
    }
}
