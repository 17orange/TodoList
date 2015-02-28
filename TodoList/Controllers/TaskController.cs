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
        public ActionResult Create([Bind(Include = "userID,name,description,deadlineTime,isPublic")] TodoTask todoTask)
        {
            todoTask.CreationTime = DateTime.Now;
            todoTask.StatusID = TodoList.Models.Status.NEEDS_DONE;

            if (ModelState.IsValid)
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
        public ActionResult Edit([Bind(Include = "TodoTaskID,userID,name,description,deadlineTime,isPublic")] TodoTask todoTask)
        {
            // make sure its a valid state and they are the owner of this task
            if (ModelState.IsValid && todoTask.UserID == User.Identity.GetUserId())
            {
                // only modify these particular fields.  leave the rest alone.
                db.TodoTasks.Attach(todoTask);
                db.Entry(todoTask).Property("Name").IsModified = true;
                db.Entry(todoTask).Property("Description").IsModified = true;
                db.Entry(todoTask).Property("DeadlineTime").IsModified = true;
                db.Entry(todoTask).Property("IsPublic").IsModified = true;
                db.SaveChanges();

                // send them back to the last page they were looking at
                string redirectAction = (Session["LastAction"] == null) ? "List" : (Session["LastAction"] as string);
                return RedirectToAction(redirectAction, "Home");
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
            // make sure they are the owner of this task
            TodoTask todoTask = db.TodoTasks.Find(id);
            if (todoTask.UserID == User.Identity.GetUserId())
            {
                db.TodoTasks.Remove(todoTask);
                db.SaveChanges();

                // send them back to the last page they were looking at
                string redirectAction = (Session["LastAction"] == null) ? "List" : (Session["LastAction"] as string);
                return RedirectToAction(redirectAction, "Home");
            }
            return View(todoTask);
        }

        // POST: Task/ChangeStatus/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(int id, int statusID)
        {
            // make sure they are the owner of this task
            TodoTask todoTask = db.TodoTasks.Find(id);
            // make sure they are the owner of this task
            if (todoTask.UserID == User.Identity.GetUserId())
            {
                // only modify these particular fields.  leave the rest alone.
                todoTask.StatusID = statusID;
                db.TodoTasks.Attach(todoTask);
                db.Entry(todoTask).Property("StatusID").IsModified = true;
                db.SaveChanges();

                // send them back to the last page they were looking at
                string redirectAction = (Session["LastAction"] == null) ? "List" : (Session["LastAction"] as string);
                return RedirectToAction(redirectAction, "Home");
            }
            return View(todoTask);
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
