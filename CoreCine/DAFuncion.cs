using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAFuncion
    {

        static public List<Funcion> ListadoFuncion()
        {
            List<Funcion> listadoFuncion = new List<Funcion>();
            using (var data = new CineDATABASEEntities())
            {

                listadoFuncion = data.Funcion.ToList();

            }
            return listadoFuncion;
        }

        /// Registrar Funcion
        //////////////////////////////////////////////////////

        static public bool RegistrarFuncion(Funcion Funcion)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Funcion.Add(Funcion);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Funcion
        //////////////////////////////////////////////////////
        static public bool ActualizarFuncion(Funcion Funcion) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Funcion actual = data.Funcion.Where(x => x.CodFuncion == Funcion.CodFuncion).FirstOrDefault();// alias
                    actual.HoraInicio = Funcion.HoraInicio;
                    actual.HoraFin = Funcion.HoraFin;
                    actual.CodPelicula= Funcion.CodPelicula;
                    actual.FechaFuncion = Funcion.FechaFuncion;
                    actual.Precio = Funcion.Precio;
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar Funcion
        //////////////////////////////////////////////////////
        static public bool EliminarFuncion(int CodFuncion) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Funcion Funcion = data.Funcion.Where(x => x.CodFuncion == CodFuncion).FirstOrDefault();// alias

                    data.Funcion.Remove(Funcion);
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
