using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NetMvc.Cms.Model.Entities
{
    public partial class Role_Permission : EntityBase
    {
        public int ID { get; set; }

        public int Function_ActionID { get; set; }

        [StringLength(32)]
        public string AppRoleId { get; set; }
    }
}
