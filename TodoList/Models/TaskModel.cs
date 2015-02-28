using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime CreationTime { get; set; }

        // deadline timestamp
        public Nullable<DateTime> DeadlineTime { get; set; }

        // the status of this task
        public int StatusID { get; set; }
        [ForeignKey("StatusID")]
        public Status TaskStatus { get; set; }

        // whether other users can see this task or not
        public bool IsPublic { get; set; }
    }

    public class Status
    {
        public const int NEEDS_DONE = 1;
        public const int IN_PROGRESS = 2;
        public const int COMPLETE = 3;

        // ID for the status
        public int StatusID { get; set; }

        // name of the status
        [Required]
        public string Name { get; set; }
    }

    public class TodoTaskDBContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<Status> StatusTypes { get; set; }
    }
}