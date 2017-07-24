using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DATicket
    {

        static public List<Ticket> ListadoTicket()
        {
            List<Ticket> listadoTicket = new List<Ticket>();
            using (var data = new CineDATABASEEntities())
            {

                listadoTicket = data.Ticket.ToList();

            }
            return listadoTicket;
        }

        static public List<Asiento> ListadoAsiento()
        {
            List<Asiento> listadoAsiento = new List<Asiento>();
            using (var data = new CineDATABASEEntities())
            {

                listadoAsiento = data.Asiento.ToList();

            }
            return listadoAsiento;
        }

        static public List<Persona> ListadoPersona()
        {
            List<Persona> listadoPersona = new List<Persona>();
            using (var data = new CineDATABASEEntities())
            {

                listadoPersona = data.Persona.ToList();

            }

            return listadoPersona;
        }

        static public List<Funcion> ListadoFuncion()
        {
            List<Funcion> listadoFuncion = new List<Funcion>();
            using (var data = new CineDATABASEEntities())
            {

                listadoFuncion = data.Funcion.ToList();

            }
            return listadoFuncion;
        }
        /// Registrar Ticket
        //////////////////////////////////////////////////////

        static public bool RegistrarTicket(Ticket Ticket)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Ticket.Add(Ticket);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Ticket
        //////////////////////////////////////////////////////
        static public bool ActualizarTicket(Ticket Ticket) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Ticket actual = data.Ticket.Where(x => x.CodTicket == Ticket.CodTicket).FirstOrDefault();// alias
                    actual.Descripcion = Ticket.Descripcion;
                    actual.CodAsiento = Ticket.CodAsiento;
                    actual.CodPersona = Ticket.CodPersona;
                    actual.CodFuncion = Ticket.CodFuncion;
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar Pelicula
        //////////////////////////////////////////////////////
        static public bool EliminarTicket(int CodTicket) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Ticket Ticket = data.Ticket.Where(x => x.CodTicket == CodTicket).FirstOrDefault();// alias

                    data.Ticket.Remove(Ticket);
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {

                exito = false;
            }

            return exito;
        }

    }
}
