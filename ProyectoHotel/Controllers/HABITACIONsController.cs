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
    public class HABITACIONsController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: HABITACIONs
        public ActionResult Index()
        {
            var hABITACIONs = db.HABITACIONs.Include(h => h.CATEGORIA).Include(h => h.ESTADO_HABITACION).Include(h => h.PISO);
            return View(hABITACIONs.ToList());
        }

        // GET: HABITACIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            return View(hABITACION);
        }

        // GET: HABITACIONs/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion");
            ViewBag.IdEstadoHabitacion = new SelectList(db.ESTADO_HABITACION, "IdEstadoHabitacion", "Descripcion");
            ViewBag.IdPiso = new SelectList(db.PISOes, "IdPiso", "Descripcion");
            return View();
        }

        // POST: HABITACIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHabitacion,Numero,Detalle,Precio,IdEstadoHabitacion,IdPiso,IdCategoria,Estado,FechaCreacion")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                db.HABITACIONs.Add(hABITACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion", hABITACION.IdCategoria);
            ViewBag.IdEstadoHabitacion = new SelectList(db.ESTADO_HABITACION, "IdEstadoHabitacion", "Descripcion", hABITACION.IdEstadoHabitacion);
            ViewBag.IdPiso = new SelectList(db.PISOes, "IdPiso", "Descripcion", hABITACION.IdPiso);
            return View(hABITACION);
        }

        // GET: HABITACIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion", hABITACION.IdCategoria);
            ViewBag.IdEstadoHabitacion = new SelectList(db.ESTADO_HABITACION, "IdEstadoHabitacion", "Descripcion", hABITACION.IdEstadoHabitacion);
            ViewBag.IdPiso = new SelectList(db.PISOes, "IdPiso", "Descripcion", hABITACION.IdPiso);
            return View(hABITACION);
        }

        // POST: HABITACIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHabitacion,Numero,Detalle,Precio,IdEstadoHabitacion,IdPiso,IdCategoria,Estado,FechaCreacion")] HABITACION hABITACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hABITACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion", hABITACION.IdCategoria);
            ViewBag.IdEstadoHabitacion = new SelectList(db.ESTADO_HABITACION, "IdEstadoHabitacion", "Descripcion", hABITACION.IdEstadoHabitacion);
            ViewBag.IdPiso = new SelectList(db.PISOes, "IdPiso", "Descripcion", hABITACION.IdPiso);
            return View(hABITACION);
        }

        // GET: HABITACIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            if (hABITACION == null)
            {
                return HttpNotFound();
            }
            return View(hABITACION);
        }

        // POST: HABITACIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HABITACION hABITACION = db.HABITACIONs.Find(id);
            db.HABITACIONs.Remove(hABITACION);
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
