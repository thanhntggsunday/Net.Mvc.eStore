using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.DAL
{
    public static class DbModelBuilderExtension
    {
        public static void CreateAspNetModel(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("AppUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AppRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AppUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AppUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AppUserClaims");
        }

    }
}
