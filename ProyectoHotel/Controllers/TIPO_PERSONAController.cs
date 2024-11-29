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
    public class TIPO_PERSONAController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: TIPO_PERSONA
        public ActionResult Index()
        {
            return View(db.TIPO_PERSONA.ToList());
        }

        // GET: TIPO_PERSONA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PERSONA tIPO_PERSONA = db.TIPO_PERSONA.Find(id);
            if (tIPO_PERSONA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PERSONA);
        }

        // GET: TIPO_PERSONA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_PERSONA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPersona,Descripcion,Estado,FechaCreacion")] TIPO_PERSONA tIPO_PERSONA)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_PERSONA.Add(tIPO_PERSONA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_PERSONA);
        }

        // GET: TIPO_PERSONA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PERSONA tIPO_PERSONA = db.TIPO_PERSONA.Find(id);
            if (tIPO_PERSONA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PERSONA);
        }

        // POST: TIPO_PERSONA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPersona,Descripcion,Estado,FechaCreacion")] TIPO_PERSONA tIPO_PERSONA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_PERSONA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_PERSONA);
        }

        // GET: TIPO_PERSONA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_PERSONA tIPO_PERSONA = db.TIPO_PERSONA.Find(id);
            if (tIPO_PERSONA == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_PERSONA);
        }

        // POST: TIPO_PERSONA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_PERSONA tIPO_PERSONA = db.TIPO_PERSONA.Find(id);
            db.TIPO_PERSONA.Remove(tIPO_PERSONA);
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
