using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace TodoList.Models
{
    // this class defines our task model
    public class TodoTask
    {
        // ID for the task itself
        public int TodoTaskID { get; set; }

        // ID of the creator of this task
        public string UserID { get; set; }

        // short description of the task
        [Display(Name="Task Name")]
        [Required]
        public string Name { get; set; }

        // full description of the task
        [Display(Name = "Full Description")]
        [Required]
        public string Description { get; set; }

        // creation timestamp
        public DateTime CreationTime { get; set; }

        // deadline timestamp
        public bool HasDeadline { get; set; }
        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:HH:mm:ss MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeadlineTime { get; set; }

        // the status of this task
        public int StatusID { get; set; }

        // whether other users can see this task or not
        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
    }

    public class TodoTaskDBContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}