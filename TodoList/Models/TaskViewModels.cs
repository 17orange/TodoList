﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TodoList.Models
{
    public class CreateTaskViewModel
    {
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:HH:mm:ss MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeadlineTime { get; set; }

        // whether other users can see this task or not
        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
    }

    public class DisplayTaskViewModel : CreateTaskViewModel
    {
        // ID for the task itself
        public int TodoTaskID { get; set; }

        // ID of the creator of this task
        public string UserID { get; set; }

        // username of the person who created this
        [Display(Name = "User Name")]
        public string Username { get; set; }

        // creation timestamp
        public DateTime CreationTime { get; set; }

        // the status of this task
        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }
}