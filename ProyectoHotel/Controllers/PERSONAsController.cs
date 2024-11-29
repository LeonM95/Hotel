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
    public class PERSONAsController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: PERSONAs
        public ActionResult Index()
        {
            var pERSONAs = db.PERSONAs.Include(p => p.TIPO_PERSONA);
            return View(pERSONAs.ToList());
        }

        // GET: PERSONAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONAs.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA);
        }

        // GET: PERSONAs/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Descripcion");
            return View();
        }

        // POST: PERSONAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersona,TipoDocumento,Documento,Nombre,Apellido,Correo,Clave,IdTipoPersona,Estado,FechaCreacion")] PERSONA pERSONA)
        {
            if (ModelState.IsValid)
            {
                db.PERSONAs.Add(pERSONA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Descripcion", pERSONA.IdTipoPersona);
            return View(pERSONA);
        }

        // GET: PERSONAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONAs.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Descripcion", pERSONA.IdTipoPersona);
            return View(pERSONA);
        }

        // POST: PERSONAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersona,TipoDocumento,Documento,Nombre,Apellido,Correo,Clave,IdTipoPersona,Estado,FechaCreacion")] PERSONA pERSONA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pERSONA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPersona = new SelectList(db.TIPO_PERSONA, "IdTipoPersona", "Descripcion", pERSONA.IdTipoPersona);
            return View(pERSONA);
        }

        // GET: PERSONAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERSONA pERSONA = db.PERSONAs.Find(id);
            if (pERSONA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA);
        }

        // POST: PERSONAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERSONA pERSONA = db.PERSONAs.Find(id);
            db.PERSONAs.Remove(pERSONA);
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
