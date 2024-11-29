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
    public class DETALLE_VENTAController : Controller
    {
        private DB_HOTELEntities db = new DB_HOTELEntities();

        // GET: DETALLE_VENTA
        public ActionResult Index()
        {
            var dETALLE_VENTA = db.DETALLE_VENTA.Include(d => d.PRODUCTO).Include(d => d.VENTA);
            return View(dETALLE_VENTA.ToList());
        }

        // GET: DETALLE_VENTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_VENTA dETALLE_VENTA = db.DETALLE_VENTA.Find(id);
            if (dETALLE_VENTA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_VENTA);
        }

        // GET: DETALLE_VENTA/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre");
            ViewBag.IdVenta = new SelectList(db.VENTAs, "IdVenta", "Estado");
            return View();
        }

        // POST: DETALLE_VENTA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleVenta,IdVenta,IdProducto,Cantidad,SubTotal")] DETALLE_VENTA dETALLE_VENTA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_VENTA.Add(dETALLE_VENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLE_VENTA.IdProducto);
            ViewBag.IdVenta = new SelectList(db.VENTAs, "IdVenta", "Estado", dETALLE_VENTA.IdVenta);
            return View(dETALLE_VENTA);
        }

        // GET: DETALLE_VENTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_VENTA dETALLE_VENTA = db.DETALLE_VENTA.Find(id);
            if (dETALLE_VENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLE_VENTA.IdProducto);
            ViewBag.IdVenta = new SelectList(db.VENTAs, "IdVenta", "Estado", dETALLE_VENTA.IdVenta);
            return View(dETALLE_VENTA);
        }

        // POST: DETALLE_VENTA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleVenta,IdVenta,IdProducto,Cantidad,SubTotal")] DETALLE_VENTA dETALLE_VENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_VENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLE_VENTA.IdProducto);
            ViewBag.IdVenta = new SelectList(db.VENTAs, "IdVenta", "Estado", dETALLE_VENTA.IdVenta);
            return View(dETALLE_VENTA);
        }

        // GET: DETALLE_VENTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_VENTA dETALLE_VENTA = db.DETALLE_VENTA.Find(id);
            if (dETALLE_VENTA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_VENTA);
        }

        // POST: DETALLE_VENTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_VENTA dETALLE_VENTA = db.DETALLE_VENTA.Find(id);
            db.DETALLE_VENTA.Remove(dETALLE_VENTA);
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
