using System.ComponentModel.DataAnnotations;

namespace NetMvc.Cms.Model.Entities
{
    public partial class AppUserLogin
    {
        [Key]
        public string UserId { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        [StringLength(128)]
        public string AppUser_Id { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
