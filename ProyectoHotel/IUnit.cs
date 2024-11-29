using ProyectoHotel.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel
{
    public interface IUnit 
    {
        ILoginRepository Login { get; }

        IHabitacionesRepository Habitaciones { get; }

        int complete();
    }
}