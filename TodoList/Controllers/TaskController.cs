using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TaskController : Controller
    {
        private TodoTaskDBContext db = new TodoTaskDBContext();

        // GET: Task
        public ActionResult Index()
        {
            return View(db.TodoTasks.ToList());
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
        public ActionResult Create([Bind(Include = "TodoTaskID,userID,name,description,creationTime,deadlineTime,statusID,isPublic")] TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                db.TodoTasks.Add(todoTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoTask);
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
