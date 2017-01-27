using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MvcMusicStore.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcMusicStore.Startup))]
namespace MvcMusicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoleandUser();
        }

        public async void CreateRoleandUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userdb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                
            }

            //if (!userdb.Users.Any(row => row.Email == "admin@gmail.com"))
            //{
            //    var user = new ApplicationUser();
            //    user.UserName = "admin";
            //    user.Email = "admin@gmail.com";

            //    string password = "Password123!";

            //    var usermanager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //    var result = await usermanager.CreateAsync(user, password);

            //    //var chkUser = userManager.Create(user, password);
            //    if (result.Succeeded)
            //    {
            //        userdb.AddToRole(user.Id, "Admin");
            //    }

            //}

        }
    }
}
