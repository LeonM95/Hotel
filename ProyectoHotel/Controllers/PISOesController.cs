using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoHotel.Models;

namespace ProyectoHotel.Controllers
{
    public class PISOesController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: PISOes
        public ActionResult Index()
        {
            return View(db.PISOes.ToList());
        }

        // GET: PISOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PISO pISO = db.PISOes.Find(id);
            if (pISO == null)
            {
                return HttpNotFound();
            }
            return View(pISO);
        }

        // GET: PISOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PISOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPiso,Descripcion,Estado,FechaCreacion")] PISO pISO)
        {
            if (ModelState.IsValid)
            {
                db.PISOes.Add(pISO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pISO);
        }

        // GET: PISOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PISO pISO = db.PISOes.Find(id);
            if (pISO == null)
            {
                return HttpNotFound();
            }
            return View(pISO);
        }

        // POST: PISOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPiso,Descripcion,Estado,FechaCreacion")] PISO pISO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pISO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pISO);
        }

        // GET: PISOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PISO pISO = db.PISOes.Find(id);
            if (pISO == null)
            {
                return HttpNotFound();
            }
            return View(pISO);
        }

        // POST: PISOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PISO pISO = db.PISOes.Find(id);
            db.PISOes.Remove(pISO);
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
