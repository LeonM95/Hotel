using ProyectoHotel.IRepository;
using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace ProyectoHotel.Repository
{
    public class LoginRepository : ILoginRepository
    {
        //connection
        private DB_HOTELEntities model_Context { get; set; }

        //mapp connection type
        public LoginRepository(DB_HOTELEntities _context) {
            model_Context = _context;
        }

        public Persona Login(string correo, string clave)
        {
            var existUser = (from user in model_Context.PERSONAs
                             join userType in model_Context.TIPO_PERSONA
                             on user.IdTipoPersona equals userType.IdTipoPersona
                             where user.Correo == correo && user.Clave == clave
                             select new Persona 
                             {
                                 IdPersona = user.IdPersona,
                                 TipoDocumento = user.TipoDocumento,
                                 Documento = user.Documento,
                                 Nombre = user.Nombre,
                                 Apellido = user.Apellido,
                                 Correo = user.Correo,
                                 Clave = user.Clave,
                                 oTipoPersona = new TipoPersona() { IdTipoPersona = userType.IdTipoPersona, Descripcion = userType.Descripcion.ToString() },
                                 Estado = userType.Estado?? false                            
                             }).First();
            return existUser;
        }


        public void LogoutUser()
        {
            
        }
    }
}