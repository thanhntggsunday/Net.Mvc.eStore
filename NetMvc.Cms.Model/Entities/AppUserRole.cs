using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetMvc.Cms.Model.Entities
{
    public partial class AppUserRole
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string RoleId { get; set; }

        [StringLength(128)]
        public string IdentityRole_Id { get; set; }

        [StringLength(128)]
        public string AppUser_Id { get; set; }

        public virtual AppRole AppRole { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}