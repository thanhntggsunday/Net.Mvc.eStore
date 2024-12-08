using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Model.Entities
{
    public partial class AppUserClaim
    {
        [Key]
        public string UserId { get; set; }

        public int Id { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [StringLength(128)]
        public string AppUser_Id { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
