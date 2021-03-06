﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using frontmiddleend.Models;

namespace frontmiddleend.Controllers
{
    public class TimeSlotsController : Controller
    {
        private Entities db = new Entities();

        // GET: TimeSlots
        public ActionResult Index()
        {
            return View(db.TimeSlots.ToList());
        }

        // GET: TimeSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            if (timeSlots == null)
            {
                return HttpNotFound();
            }
            return View(timeSlots);
        }

        // GET: TimeSlots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSlots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeID,SlotTime")] TimeSlots timeSlots)
        {
            if (ModelState.IsValid)
            {
                db.TimeSlots.Add(timeSlots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeSlots);
        }

        // GET: TimeSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            if (timeSlots == null)
            {
                return HttpNotFound();
            }
            return View(timeSlots);
        }

        // POST: TimeSlots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeID,SlotTime")] TimeSlots timeSlots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSlots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeSlots);
        }

        // GET: TimeSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            if (timeSlots == null)
            {
                return HttpNotFound();
            }
            return View(timeSlots);
        }

        // POST: TimeSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSlots timeSlots = db.TimeSlots.Find(id);
            db.TimeSlots.Remove(timeSlots);
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
