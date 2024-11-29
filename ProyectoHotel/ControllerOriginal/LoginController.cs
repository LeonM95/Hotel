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
    public class LoginController : Controller
    {
        //to be able to use Iunit
        private IUnit _unit { get; set; }

        public LoginController() {
            //pass connection string - access unit and logic
            var connectionString = ConfigurationManager.ConnectionStrings["DB_HOTELEntities"].ConnectionString;
            _unit =  new Unit(new DB_HOTELEntities(connectionString));
        }



        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            var ousuario = _unit.Login.Login(correo, clave);

            if (ousuario == null)
            {
                ViewBag.Error = "Usuario o contraseña no correcta";
                return View();
            }

            Session["Usuario"] = ousuario;

            return RedirectToAction("Index", "Inicio");
        }

        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}