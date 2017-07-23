using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAPelicula
    {

        static public List<Pelicula> ListadoPelicula()
        {
            List<Pelicula> listadoPelicula = new List<Pelicula>();
            using (var data = new CineDATABASEEntities())
            {

                listadoPelicula = data.Pelicula.ToList();

            }
            return listadoPelicula;
        }

        /// Registrar Pelicula
        //////////////////////////////////////////////////////

        static public bool RegistrarPelicula(Pelicula Pelicula)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Pelicula.Add(Pelicula);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Pelicula
        //////////////////////////////////////////////////////
        static public bool ActualizarPelicula(Pelicula Pelicula) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Pelicula actual = data.Pelicula.Where(x => x.CodPelicula == Pelicula.CodPelicula).FirstOrDefault();// alias
                    actual.NombrePelicula = Pelicula.NombrePelicula;
                    actual.Duracion = Pelicula.Duracion;
                    actual.FechaEstreno = Pelicula.FechaEstreno;
                    actual.CodDirector = Pelicula.CodDirector;
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
        static public bool EliminarPelicula(int CodPelicula) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Pelicula Pelicula = data.Pelicula.Where(x => x.CodPelicula == CodPelicula).FirstOrDefault();// alias

                    data.Pelicula.Remove(Pelicula);
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
