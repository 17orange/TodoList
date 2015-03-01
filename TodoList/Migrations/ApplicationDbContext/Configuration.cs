namespace TodoList.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TodoList.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoList.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationDbContext";
        }

        protected override void Seed(TodoList.Models.ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var hasher = new PasswordHasher();

            // make user 1
            var user = new ApplicationUser
            {
                Id = "10359014-0cbe-4793-bd7e-53d70866b3cf",
                UserName = "brad",
                PasswordHash = hasher.HashPassword("P4$$w0rd"),
                SecurityStamp = "02cdea75-bd97-4732-880f-9dc9b9d85b3b",
                Email = "bradley.patton@gmail.com"
            };
            manager.Create(user, "P4$$w0rd");

            // make user 2
            user = new ApplicationUser
            {
                Id = "f618eaa9-cb54-4a28-a1ca-df007389792a",
                UserName = "OtherGuy",
                PasswordHash = hasher.HashPassword("Zomg!23"),
                SecurityStamp = "7756dd15-bb43-49bc-b814-fce2a846a89d",
                Email = "not@real.com"
            };
            manager.Create(user, "Zomg!23");
        }
    }
}
