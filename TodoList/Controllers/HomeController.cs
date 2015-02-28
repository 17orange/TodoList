using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private TodoTaskDBContext db = new TodoTaskDBContext();

        public ActionResult Index()
        {
            // keep track of what was the last view we were looking at
            Session.Add("LastAction", "Index");

            // show them any tasks that are public or belong to them
            string userID = User.Identity.GetUserId();
            string query = "select TodoTaskID, UserID, Username, TodoTasks.Name as Name, Description, CreationTime, DeadlineTime, CompletionTime, IsPublic, TodoTasks.StatusID, Status.Name as StatusName, IIF(TodoTasks.UserID='" + userID + "',1,0) as isMe, IIF(DeadlineTime is null,0,1) as hasDeadline, IIF(TodoTasks.StatusID=3,CompletionTime,'9999-12-31') as finishTime " + 
                           "from TodoTasks join AspNetUsers on UserID=Id join Status on TodoTasks.StatusID=Status.StatusID " + 
                           "where isPublic = 1 or TodoTasks.UserID='" + userID + "'" +
                           "order by isMe desc, UserID, finishTime desc, hasDeadline desc, DeadlineTime";
            var taskList = db.Database.SqlQuery<DisplayTaskViewModel>(query);

            return View(taskList);
        }
    }
}