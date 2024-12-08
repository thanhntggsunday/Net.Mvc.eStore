using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetMvc.Cms.Model.Entities
{

    [Table("AppRoles")]
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {
        }

        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        public virtual string Description { get; set; }

        public virtual ICollection<Role_Permission> Role_Permission { get; set; }
    }
}