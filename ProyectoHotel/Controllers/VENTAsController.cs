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
    public class VENTAsController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: VENTAs
        public ActionResult Index()
        {
            var vENTAs = db.VENTAs.Include(v => v.RECEPCION);
            return View(vENTAs.ToList());
        }

        // GET: VENTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTAs.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // GET: VENTAs/Create
        public ActionResult Create()
        {
            ViewBag.IdRecepcion = new SelectList(db.RECEPCIONs, "IdRecepcion", "Observacion");
            return View();
        }

        // POST: VENTAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenta,IdRecepcion,Total,Estado")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.VENTAs.Add(vENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRecepcion = new SelectList(db.RECEPCIONs, "IdRecepcion", "Observacion", vENTA.IdRecepcion);
            return View(vENTA);
        }

        // GET: VENTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTAs.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRecepcion = new SelectList(db.RECEPCIONs, "IdRecepcion", "Observacion", vENTA.IdRecepcion);
            return View(vENTA);
        }

        // POST: VENTAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenta,IdRecepcion,Total,Estado")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRecepcion = new SelectList(db.RECEPCIONs, "IdRecepcion", "Observacion", vENTA.IdRecepcion);
            return View(vENTA);
        }

        // GET: VENTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTAs.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // POST: VENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTA vENTA = db.VENTAs.Find(id);
            db.VENTAs.Remove(vENTA);
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
