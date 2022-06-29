using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class User_detailController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: User_detail
        public ActionResult Index()
        {
            return View(db.User_detail.ToList());
        }

        // GET: User_detail/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_detail user_detail = db.User_detail.Find(id);
            if (user_detail == null)
            {
                return HttpNotFound();
            }
            return View(user_detail);
        }

        // GET: User_detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,contact,UserType")] User_detail user_detail)
        {
            if (ModelState.IsValid)
            {
                db.User_detail.Add(user_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_detail);
        }

        // GET: User_detail/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_detail user_detail = db.User_detail.Find(id);
            if (user_detail == null)
            {
                return HttpNotFound();
            }
            return View(user_detail);
        }

        // POST: User_detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,contact,UserType")] User_detail user_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_detail);
        }

        // GET: User_detail/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_detail user_detail = db.User_detail.Find(id);
            if (user_detail == null)
            {
                return HttpNotFound();
            }
            return View(user_detail);
        }

        // POST: User_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User_detail user_detail = db.User_detail.Find(id);
            db.User_detail.Remove(user_detail);
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
