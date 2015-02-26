﻿using System;
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
            Session.Add("LastController", "Home");
            Session.Add("LastAction", "Index");

            //return View(db.TodoTasks.Where(t => t.IsPublic || (t.UserID == User.Identity.GetUserId())));
            return View(db.TodoTasks.ToList());
        }
    }
}