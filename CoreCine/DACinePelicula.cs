using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DACinePelicula
    {
        static public List<CinePelicula> ListadoCinePelicula()
        {
            List<CinePelicula> listadoCP = new List<CinePelicula>();
            using (var data = new CineDATABASEEntities())
            {

                listadoCP = data.CinePelicula.ToList();

            }
            return listadoCP;
        }

        static public List<Pelicula> ListadoPelicula()
        {
            List<Pelicula> listadoPelicula = new List<Pelicula>();
            using (var data = new CineDATABASEEntities())
            {

                listadoPelicula = data.Pelicula.ToList();

            }
            return listadoPelicula;
        }

        /// Registrar CinePelicula
        //////////////////////////////////////////////////////

        static public bool RegistrarCinePelicula(CinePelicula CinePelicula)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.CinePelicula.Add(CinePelicula);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar CinePelicula
        //////////////////////////////////////////////////////
        static public bool ActualizarCinePelicula(CinePelicula CinePelicula) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {

                    // realizar la consulta y actualizar
                    CinePelicula actual = data.CinePelicula.Where(x => x.CodCine == CinePelicula.CodCine).FirstOrDefault();// alias
                    actual.CodPelicula = CinePelicula.CodPelicula;
                    actual.EnCartelera = CinePelicula.EnCartelera;
                    data.SaveChanges();

                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar CinePelicula
        //////////////////////////////////////////////////////
        static public bool EliminarCinePelicula(int CodCine) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    CinePelicula CinePelicula = data.CinePelicula.Where(x => x.CodCine == CodCine).FirstOrDefault();// alias

                    data.CinePelicula.Remove(CinePelicula);
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
