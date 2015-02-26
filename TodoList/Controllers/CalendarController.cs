using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class CalendarController : Controller
    {
        private TodoTaskDBContext db = new TodoTaskDBContext();

        // GET: Calendar/Day
        public ActionResult Day()
        {
            // keep track of what was the last view we were looking at
            Session.Add("LastController", "Calendar");
            Session.Add("LastAction", "Day");

            return View(db.TodoTasks.ToList());
        }
    }
}