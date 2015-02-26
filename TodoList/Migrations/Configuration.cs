namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoList.Models.TodoTaskDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TodoList.Models.TodoTaskDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // reset the key back to 1
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('TodoTasks', RESEED, 0)");

            // clean out the first three
            context.TodoTasks.RemoveRange(context.TodoTasks.Where(t => (t.TodoTaskID <= 3)));
            context.SaveChanges();

            // add them back in
            context.TodoTasks.AddOrUpdate(
                t => t.TodoTaskID,
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 1,
                    UserID = "10359014-0cbe-4793-bd7e-53d70866b3cf",
                    CreationTime = DateTime.Parse("2015-02-25 12:34:56"),
                    Name = "Unspecified Task",
                    Description = "Just get this done at some point, doesn't matter when",
                    HasDeadline = false,
                    DeadlineTime = DateTime.Now,
                    IsPublic = true
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 2,
                    UserID = "10359014-0cbe-4793-bd7e-53d70866b3cf",
                    CreationTime = DateTime.Parse("2015-02-25 14:34:56"),
                    Name = "Build Todo List Tracker",
                    Description = "This needs done by Monday morning.",
                    HasDeadline = true,
                    DeadlineTime = DateTime.Parse("2015-03-02 08:00:00"),
                    IsPublic = true
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 3,
                    UserID = "10359014-0cbe-4793-bd7e-53d70866b3cf",
                    CreationTime = DateTime.Parse("2015-02-25 15:34:56"),
                    Name = "Buy Ash Christmas present",
                    Description = "Make sure it's something she likes or you're in trouble.",
                    HasDeadline = true,
                    DeadlineTime = DateTime.Parse("2015-12-25 04:00:00"),
                    IsPublic = false
                }
            );
        }
    }
}
