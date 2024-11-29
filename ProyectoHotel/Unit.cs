using ProyectoHotel.IRepository;
using ProyectoHotel.Models;
using ProyectoHotel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoHotel
{
    public class Unit : IUnit
    {
        //to get connection
        private DB_HOTELEntities model_Context { get ; set; }

        public ILoginRepository Login {get; private set;}

        public IHabitacionesRepository Habitaciones { get; private set; }

        public Unit(DB_HOTELEntities _context) {
            //to pass connection that we will use on this repository
            model_Context = _context;
            Login = new LoginRepository(_context);
            Habitaciones = new HabitacionesRepository(_context);
        }


        public int complete()
        {
            //use to save changes
           return model_Context.SaveChanges();
        }
    }
}