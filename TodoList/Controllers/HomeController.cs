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

        public ActionResult List()
        {
            // keep track of what was the last view we were looking at
            Session.Add("LastAction", "List");

            // show them any tasks that are public or belong to them
            string userID = User.Identity.GetUserId();
            string query = "select * from TodoTasks join AspNetUsers on UserID=Id order by UserID, DeadlineTime";
            var taskList = db.Database.SqlQuery<DisplayTaskViewModel>(query);

            /*
            var taskList = db.TodoTasks.Where(t => ((t.IsPublic == true) || (t.UserID == userID)));
            taskList = from t in taskList
                       join u in db.AspNetUsers on t.UserID equals u.Id
                       select new {
                           TaskID = t.TodoTaskID,
                           Username = u.UserName,
                           TaskName = t.Name,
                           Deadline = t.DeadlineTime
                       }
             */
            return View(taskList);
        }
    }
}