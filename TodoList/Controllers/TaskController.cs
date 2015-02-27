using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using Microsoft.AspNet.Identity;

namespace TodoList.Controllers
{
    public class TaskController : Controller
    {
        private TodoTaskDBContext db = new TodoTaskDBContext();

        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        // GET: Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTask todoTask = db.TodoTasks.Find(id);
            if (todoTask == null)
            {
                return HttpNotFound();
            }
            return View(todoTask);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "TodoTaskID,UserID,Name,Description,CreationTime,DeadlineTime,StatusID,IsPublic")] TodoTask todoTask)
        public ActionResult Create([Bind(Include = "userID,name,description,deadlineTime,isPublic")] TodoTask todoTask)
        {
            todoTask.UserID = User.Identity.GetUserId();
            todoTask.CreationTime = DateTime.Now;
            todoTask.StatusID = 1;
            if (true || ModelState.IsValid)
            {
                db.TodoTasks.Add(todoTask);
                db.SaveChanges();

                // send them back to the last page they were looking at
                string redirectAction = (Session["LastAction"] == null) ? "List" : (Session["LastAction"] as string);
                return RedirectToAction(redirectAction, "Home");
            }

            return View();
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTask todoTask = db.TodoTasks.Find(id);
            if (todoTask == null)
            {
                return HttpNotFound();
            }
            return View(todoTask);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TodoTaskID,userID,name,description,creationTime,deadlineTime,statusID,isPublic")] TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoTask);
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoTask todoTask = db.TodoTasks.Find(id);
            if (todoTask == null)
            {
                return HttpNotFound();
            }
            return View(todoTask);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoTask todoTask = db.TodoTasks.Find(id);
            db.TodoTasks.Remove(todoTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
