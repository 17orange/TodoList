using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TodoList.Models
{
    public class CreateTaskViewModel
    {
        // ID of the creator of this task
        [HiddenInput]
        [Required]
        public string UserID { get; set; }

        // short description of the task
        [Display(Name = "Task Name")]
        [Required]
        public string Name { get; set; }

        // full description of the task
        [Display(Name = "Full Description")]
        [Required]
        public string Description { get; set; }

        // deadline timestamp
        [Display(Name = "Deadline")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:h:MM-dd-yyyy}", ApplyFormatInEditMode=true)]
        [DisplayFormat(DataFormatString = "{0:h:mmtt on MMM d, yyyy}")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:HH:mm:ss MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeadlineTime { get; set; }

        // creation timestamp
        public DateTime? CreationTime { get; set; }

        // the status of this task
        public int StatusID { get; set; }

        // whether other users can see this task or not
        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
    }

    public class DisplayTaskViewModel : CreateTaskViewModel
    {
        // ID for the task itself
        public int TodoTaskID { get; set; }

        // username of the person who created this
        [Display(Name = "User Name")]
        public string Username { get; set; }

        // the status of this task
        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }
}