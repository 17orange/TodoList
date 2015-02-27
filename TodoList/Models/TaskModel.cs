using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TodoList.Models
{
    // this class defines our task model
    public class TodoTask
    {
        // ID for the task itself
        public int TodoTaskID { get; set; }

        // ID of the creator of this task
        [Required]
        public string UserID { get; set; }

        // short description of the task
        [Required]
        public string Name { get; set; }

        // full description of the task
        [Required]
        public string Description { get; set; }

        // creation timestamp
        [Required]
        public DateTime CreationTime { get; set; }

        // deadline timestamp
        public Nullable<DateTime> DeadlineTime { get; set; }

        // the status of this task
        public int StatusID { get; set; }

        // whether other users can see this task or not
        public bool IsPublic { get; set; }
    }

    public class TodoTaskDBContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}