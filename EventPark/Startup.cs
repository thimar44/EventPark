using EventPark.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventPark.Startup))]
namespace EventPark
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
            using (EparkContext context = new EparkContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    // first we create Admin rool
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website				
                    var user = new ApplicationUser();
                    user.UserName = "admin@crazyevent.com";
                    user.Email = "admin@crazyevent.com";

                    string userPWD = "Pa$$w0rd";

                    var chkUser = userManager.Create(user, userPWD);

                    //Add default User to Role Admin
                    if (chkUser.Succeeded)
                    {
                        userManager.AddToRole(user.Id, "Admin");
                    }
                }

                if (!roleManager.RoleExists("Visiteur"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Visiteur";
                    roleManager.Create(role);
                }

            }
        }
    }
}
