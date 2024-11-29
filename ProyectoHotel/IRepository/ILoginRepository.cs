using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel.IRepository
{
    //this is not a class is an interface
    public interface ILoginRepository
    {
        //login
        Persona Login(string correo, string clave);
        //logout
        void LogoutUser(); // Placeholder for any repository-level logout logic
    }

}