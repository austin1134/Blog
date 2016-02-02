namespace Blog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Blog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Blog.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole {Name = "Admin"});
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole {Name = "Moderator"});
            }

            var uStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(uStore);

            if (userManager.FindByEmail("austin.torres@colorado.edu") != null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "austin.torres@colorado.edu",
                    Email = "austin.torres@colorado.edu",
                    FirstName = "Austin",
                    LastName = "Torres",

                }, "TA1234ta!!");
            }

            var userId = userManager.FindByEmail("austin.torres@colorado.edu").Id;
            userManager.AddToRole(userId, "Admin");
            {
                userManager.AddToRole(userId, "Admin");
            }

            //add Bobby to the database
            if (userManager.FindByEmail("bdavis@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "bdavis@coderfoundry.com",
                    Email = "bdavis@coderfoundry.com",
                    FirstName = "Bobby",
                    LastName = "Davis"
                }, "Password-1");
            }

            userId = userManager.FindByEmail("bdavis@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            }

            if (userManager.FindByEmail("ajensen@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ajensen@coderfoundry.com",
                    Email = "ajensen@coderfoundry.com",
                    FirstName = "Andrew",
                    LastName = "Jensen"
                }, "Password-1");
            }

            userId = userManager.FindByEmail("ajensen@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            }

            if (userManager.FindByEmail("rmanglani@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rmanglani@coderfoundry.com",
                    Email = "rmanglani@coderfoundry.com",
                    FirstName = "Ria",
                    LastName = "Manglani"
                }, "Password-1");
            }

            userId = userManager.FindByEmail("rmanglani@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            }

            if (userManager.FindByEmail("tjones@coderfoundry.com") == null)
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "tjones@coderfoundry.com",
                    Email = "tjones@coderfoundry.com",
                    FirstName = "TJ",
                    LastName = "Jones"
                }, "Password-1");
            }

            userId = userManager.FindByEmail("tjones@coderfoundry.com").Id;
            if (!userManager.IsInRole(userId, "Moderator"))
            {
                userManager.AddToRole(userId, "Moderator");
            }

            //add other Coder Foundry personnel to the database (assign a default password, as above)
            // Andrew Jensen ajensen@coderfoundry.com
            //Ria Manglani rmanglani@coderfoundry.com
            //TJ Jones tjones@coderfoundry.com

        }
    }
}