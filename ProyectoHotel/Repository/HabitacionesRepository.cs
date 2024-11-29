using ProyectoHotel.IRepository;
using ProyectoHotel.Logica;
using ProyectoHotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Globalization;

namespace ProyectoHotel.Repository
{
    public class HabitacionesRepository : IHabitacionesRepository
    {
        private DB_HOTELEntities model_Context { get; set; }

        //mapp connection type
        public HabitacionesRepository(DB_HOTELEntities _context)
        {
            model_Context = _context;
        }
        public List <Habitacion> ListarHabitacion()
        {
            try
            {
                var habitaciones = (from h in model_Context.HABITACIONs
                                    join p in model_Context.PISOes on h.IdPiso equals p.IdPiso
            join c in model_Context.CATEGORIAs on h.IdCategoria equals c.IdCategoria
            join eh in model_Context.ESTADO_HABITACION on h.IdEstadoHabitacion equals eh.IdEstadoHabitacion
            select new Habitacion
            {
                IdHabitacion = h.IdHabitacion,
                Numero = h.Numero,
                Detalle = h.Detalle,
                Precio = h.Precio,
                Estado = h.Estado ?? false,
                oPiso = new Piso
                {
                    IdPiso = p.IdPiso,
                    Descripcion = p.Descripcion
                },
                oCategoria = new Categoria
                {
                    IdCategoria = c.IdCategoria,
                    Descripcion = c.Descripcion
                },
                oEstadoHabitacion = new EstadoHabitacion
                {
                    IdEstadoHabitacion = eh.IdEstadoHabitacion,
                    Descripcion = eh.Descripcion
                }
            }).ToList();

            return habitaciones;

        }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Registrar(Habitacion oHabitacion)
        {
            try
            {
                // Execute the stored procedure with parameters
                var resultadoParam = new SqlParameter("Resultado", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };

                model_Context.Database.ExecuteSqlCommand(
                    "EXEC sp_RegistrarHabitacion @Numero, @Detalle, @Precio, @IdPiso, @IdCategoria, @Resultado OUTPUT",
                    new SqlParameter("Numero", oHabitacion.Numero),
                    new SqlParameter("Detalle", oHabitacion.Detalle),
                    new SqlParameter("Precio", Convert.ToDecimal(oHabitacion.PrecioTexto, new CultureInfo("es-PE"))),
                    new SqlParameter("IdPiso", oHabitacion.oPiso.IdPiso),
                    new SqlParameter("IdCategoria", oHabitacion.oCategoria.IdCategoria),
                    resultadoParam
                );

                // Convert the output parameter value to a boolean
                bool resultado = Convert.ToBoolean(resultadoParam.Value);

                // If successful, return the Habitacion object
                if (resultado)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            
        }

        public bool Modificar(Habitacion oHabitacion)
        {
            try
            {
                // Define an output parameter to retrieve the result of the stored procedure
                var resultadoParam = new SqlParameter("Resultado", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output // Mark the parameter as OUTPUT
                };

                // Execute the stored procedure using raw SQL with the necessary parameters
                model_Context.Database.ExecuteSqlCommand(
                    "EXEC sp_ModificarHabitacion @IdHabitacion, @Numero, @Detalle, @Precio, @IdPiso, @IdCategoria, @Estado, @Resultado OUTPUT",

                    // Pass the parameters for the stored procedure
                    new SqlParameter("IdHabitacion", oHabitacion.IdHabitacion),         // Input: ID of the habitacion to modify
                    new SqlParameter("Numero", oHabitacion.Numero),                   // Input: Room number
                    new SqlParameter("Detalle", oHabitacion.Detalle),                 // Input: Room details
                    new SqlParameter("Precio", Convert.ToDecimal(oHabitacion.PrecioTexto, new CultureInfo("es-PE"))), // Input: Price (converted to decimal using "es-PE" culture)
                    new SqlParameter("IdPiso", oHabitacion.oPiso.IdPiso),             // Input: ID of the floor
                    new SqlParameter("IdCategoria", oHabitacion.oCategoria.IdCategoria), // Input: ID of the category
                    new SqlParameter("Estado", oHabitacion.Estado),                   // Input: Room state (true/false)
                    resultadoParam // Output: Result of the stored procedure (success/failure)
                );

                // Retrieve the value of the output parameter and convert it to a boolean
                return Convert.ToBoolean(resultadoParam.Value);
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed (e.g., database connection errors or invalid data)
                // Return false to indicate failure
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                // Find the habitacion record by its ID using LINQ
                var habitacion = model_Context.HABITACIONs.FirstOrDefault(h => h.IdHabitacion == id);

                // Check if the record exists in the database
                if (habitacion != null)
                {
                    // Remove/DESACTIVA the habitacion record from the DbSet
                    habitacion.Estado = false;
                    //model_Context.HABITACIONs.Remove(habitacion);

                    // Return true to indicate the operation succeeded
                    return true;
                }

                // If the record was not found, return false
                return false;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                // Return false to indicate the operation failed
                return false;
            }
        }
    }
}