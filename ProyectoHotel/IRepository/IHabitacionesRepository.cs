using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel.IRepository
{
    public interface IHabitacionesRepository
    {
        List<Habitacion> ListarHabitacion();

        bool Registrar(Habitacion oHabitacion);

        bool Modificar(Habitacion oHabitacion);

        bool Eliminar(int id);
    }
}