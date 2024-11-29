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
    public class ESTADO_HABITACIONController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: ESTADO_HABITACION
        public ActionResult Index()
        {
            return View(db.ESTADO_HABITACION.ToList());
        }

        // GET: ESTADO_HABITACION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_HABITACION eSTADO_HABITACION = db.ESTADO_HABITACION.Find(id);
            if (eSTADO_HABITACION == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_HABITACION);
        }

        // GET: ESTADO_HABITACION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADO_HABITACION/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoHabitacion,Descripcion,Estado,FechaCreacion")] ESTADO_HABITACION eSTADO_HABITACION)
        {
            if (ModelState.IsValid)
            {
                db.ESTADO_HABITACION.Add(eSTADO_HABITACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADO_HABITACION);
        }

        // GET: ESTADO_HABITACION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_HABITACION eSTADO_HABITACION = db.ESTADO_HABITACION.Find(id);
            if (eSTADO_HABITACION == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_HABITACION);
        }

        // POST: ESTADO_HABITACION/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoHabitacion,Descripcion,Estado,FechaCreacion")] ESTADO_HABITACION eSTADO_HABITACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADO_HABITACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADO_HABITACION);
        }

        // GET: ESTADO_HABITACION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_HABITACION eSTADO_HABITACION = db.ESTADO_HABITACION.Find(id);
            if (eSTADO_HABITACION == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_HABITACION);
        }

        // POST: ESTADO_HABITACION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADO_HABITACION eSTADO_HABITACION = db.ESTADO_HABITACION.Find(id);
            db.ESTADO_HABITACION.Remove(eSTADO_HABITACION);
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
