using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NetMvc.Cms.Model.Entities;

namespace NetMvc.Cms.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NetMvc.Cms.DAL.NetMvcDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NetMvc.Cms.DAL.NetMvcDbContext context)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var roles = new[] { "Admin", "Manage", "Employee" };

            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = role
                    });
                }
            }

            CreateUser(userManager, "Amin@gmail.com", "Admin@123", "Admin");
            CreateUser(userManager, "Manager@gmail.com", "Manager@123", "Manage");
            CreateUser(userManager, "Employee@gmail.com", "Employee@123", "Employee");
        }

        void CreateUser(UserManager<AppUser> userManager, string email, string password, string role)
        {
            if (userManager.FindByEmail(email) == null)
            {
                var user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = userManager.Create(user, password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, role);
                }
            }
        }
    }
}
