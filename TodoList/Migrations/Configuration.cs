namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlTypes;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoList.Models.TodoTaskDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TodoList.Models.TodoTaskDBContext context)
        {
            // reset the key back to 1
            //context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('TodoTasks', RESEED, 0)");

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
                    IsPublic = true
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 2,
                    UserID = "10359014-0cbe-4793-bd7e-53d70866b3cf",
                    CreationTime = DateTime.Parse("2015-02-25 14:34:56"),
                    Name = "Build Todo List Tracker",
                    Description = "This needs done by Monday morning.",
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
                    DeadlineTime = DateTime.Parse("2015-12-25 04:00:00"),
                    IsPublic = false
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 4,
                    UserID = "10359014-0cbe-4793-bd7e-53d70866b3cf",
                    CreationTime = DateTime.Parse("2015-02-25 16:34:56"),
                    Name = "Paint deck",
                    Description = "Redo the deck out back whenever it warms up.",
                    IsPublic = false
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 5,
                    UserID = "f618eaa9-cb54-4a28-a1ca-df007389792a",
                    CreationTime = DateTime.Parse("2015-02-26 06:34:56"),
                    Name = "Public Task (deadline)",
                    Description = "description 1",
                    DeadlineTime = DateTime.Parse("2015-03-05 00:00:00"),
                    IsPublic = true
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 6,
                    UserID = "f618eaa9-cb54-4a28-a1ca-df007389792a",
                    CreationTime = DateTime.Parse("2015-02-26 07:34:56"),
                    Name = "Public Task (whenever)",
                    Description = "description 2",
                    IsPublic = true
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 7,
                    UserID = "f618eaa9-cb54-4a28-a1ca-df007389792a",
                    CreationTime = DateTime.Parse("2015-02-26 16:34:56"),
                    Name = "Private Task (deadline)",
                    Description = "description 3",
                    DeadlineTime = DateTime.Parse("2015-03-15 00:00:00"),
                    IsPublic = false
                },
                new TodoList.Models.TodoTask
                {
                    TodoTaskID = 8,
                    UserID = "f618eaa9-cb54-4a28-a1ca-df007389792a",
                    CreationTime = DateTime.Parse("2015-02-26 19:34:56"),
                    Name = "Private Task (whenever)",
                    Description = "description 4",
                    IsPublic = false
                }
            );
        }
    }
}
