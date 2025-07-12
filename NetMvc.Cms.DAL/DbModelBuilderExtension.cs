using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace NetMvc.Cms.DAL
{
    public static class DbModelBuilderExtension
    {
        public static void CreateAspNetModel(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasKey<string>(r => r.Id)
                .ToTable("AppRoles");

            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(i => new { i.UserId, i.RoleId })
                .ToTable("AppUserRoles");

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(i => new { i.LoginProvider, i.ProviderKey, i.UserId }) 
                .ToTable("AppUserLogins");

            modelBuilder.Entity<IdentityUserClaim>()
                .HasKey(i => i.Id) 
                .ToTable("AppUserClaims");
        }

    }
}
