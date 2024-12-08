using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetMvc.Cms.Model.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [MaxLength(256)]
        public string FullName { set; get; }

        [MaxLength(500)]
        public string Address { set; get; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Avatar { get; set; }

        public DateTime? BirthDay { set; get; }

        public bool? Status { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; }
        [MaxLength(300)]
        public string Department { get; set; }
        [MaxLength(300)]
        public string Position { get; set; }
        [MaxLength(200)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string CountryRegionCode { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Postcode { get; set; }
        [MaxLength(50)]
        public string FileContentType { get; set; }

    }
}