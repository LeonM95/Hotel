using ProyectoHotel.Logica;
using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoHotel.Controllers
{
    public class HabitacionesController : Controller
    {

        //to be able to use Iunit
        private IUnit _unit { get; set; }

        public HabitacionesController()
        {
            //pass connection string - access unit and logic
            var connectionString = ConfigurationManager.ConnectionStrings["DB_HOTELEntities"].ConnectionString;
            _unit = new Unit(new DB_HOTELEntities(connectionString));
        }

        // GET: Mantenimiento
        public ActionResult Habitaciones()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            return View();
        }

        [HttpGet]
        public JsonResult ListarHabitacion()
        {
            // call repository methods 
            var oLista = _unit.Habitaciones.ListarHabitacion();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarHabitacion(Habitacion objeto)
        {
            //valida si esta object y se utilizan metodos del repository 
            bool respuesta = false;
            respuesta = (objeto.IdHabitacion == 0) ? _unit.Habitaciones.Registrar(objeto) : _unit.Habitaciones.Modificar(objeto);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarHabitacion(int id)
        {
            bool respuesta = false;

            respuesta = _unit.Habitaciones.Eliminar(id);
            _unit.complete();
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}