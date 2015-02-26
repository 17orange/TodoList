using System;
using System.Data.Entity;

namespace TodoList.Models
{
    // this class defines our task model
    public class TodoTask
    {
        // ID for the task itself
        public int TodoTaskID { get; set; }

        // ID of the creator of this task
        public string userID { get; set; }

        // short description of the task
        public string name { get; set; }

        // full description of the task
        public string description { get; set; }

        // creation timestamp
        public DateTime creationTime { get; set; }

        // deadline timestamp
        public DateTime deadlineTime { get; set; }

        // the status of this task
        public int statusID { get; set; }

        // whether other users can see this task or not
        public bool isPublic { get; set; }
    }

    public class TodoTaskDBContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}