using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetMvc.Cms.Model.Entities
{
    [Table("Action")]
    public partial class Action : EntityBase
    {
        public Action()
        {
        }

        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Function_Action> Function_Action { get; set; } = new HashSet<Function_Action>();
    }
}
