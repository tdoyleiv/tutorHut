using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using tutorHut.Models;
using System;

[assembly: OwinStartupAttribute(typeof(tutorHut.Startup))]
namespace tutorHut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!RoleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                RoleManager.Create(role);
                var user = new ApplicationUser();
                user.UserName = "tfdoyleiv";
                user.Email = "tfdoyleiv@gmail.com";
                string userPWD = "J0hnM@u$";
                var checkUser = UserManager.Create(user, userPWD);
                if (checkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!RoleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                RoleManager.Create(role);
            }
            if (!RoleManager.RoleExists("Client"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Client";
                RoleManager.Create(role);
            }
        }
    }
}
