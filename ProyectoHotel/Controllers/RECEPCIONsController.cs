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
    public class RECEPCIONsController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: RECEPCIONs
        public ActionResult Index()
        {
            var rECEPCIONs = db.RECEPCIONs.Include(r => r.HABITACION).Include(r => r.PERSONA);
            return View(rECEPCIONs.ToList());
        }

        // GET: RECEPCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCIONs.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            return View(rECEPCION);
        }

        // GET: RECEPCIONs/Create
        public ActionResult Create()
        {
            ViewBag.IdHabitacion = new SelectList(db.HABITACIONs, "IdHabitacion", "Numero");
            ViewBag.IdCliente = new SelectList(db.PERSONAs, "IdPersona", "TipoDocumento");
            return View();
        }

        // POST: RECEPCIONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRecepcion,IdCliente,IdHabitacion,FechaEntrada,FechaSalida,FechaSalidaConfirmacion,PrecioInicial,Adelanto,PrecioRestante,TotalPagado,CostoPenalidad,Observacion,Estado")] RECEPCION rECEPCION)
        {
            if (ModelState.IsValid)
            {
                db.RECEPCIONs.Add(rECEPCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHabitacion = new SelectList(db.HABITACIONs, "IdHabitacion", "Numero", rECEPCION.IdHabitacion);
            ViewBag.IdCliente = new SelectList(db.PERSONAs, "IdPersona", "TipoDocumento", rECEPCION.IdCliente);
            return View(rECEPCION);
        }

        // GET: RECEPCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCIONs.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHabitacion = new SelectList(db.HABITACIONs, "IdHabitacion", "Numero", rECEPCION.IdHabitacion);
            ViewBag.IdCliente = new SelectList(db.PERSONAs, "IdPersona", "TipoDocumento", rECEPCION.IdCliente);
            return View(rECEPCION);
        }

        // POST: RECEPCIONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRecepcion,IdCliente,IdHabitacion,FechaEntrada,FechaSalida,FechaSalidaConfirmacion,PrecioInicial,Adelanto,PrecioRestante,TotalPagado,CostoPenalidad,Observacion,Estado")] RECEPCION rECEPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECEPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHabitacion = new SelectList(db.HABITACIONs, "IdHabitacion", "Numero", rECEPCION.IdHabitacion);
            ViewBag.IdCliente = new SelectList(db.PERSONAs, "IdPersona", "TipoDocumento", rECEPCION.IdCliente);
            return View(rECEPCION);
        }

        // GET: RECEPCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCIONs.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            return View(rECEPCION);
        }

        // POST: RECEPCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECEPCION rECEPCION = db.RECEPCIONs.Find(id);
            db.RECEPCIONs.Remove(rECEPCION);
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
