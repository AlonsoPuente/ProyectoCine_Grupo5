using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAProtagonista
    {

        static public List<Protagonista> ListadoProtagonista()
        {
            List<Protagonista> listadoProtagonista = new List<Protagonista>();
            using (var data = new CineDATABASEEntities())
            {

                listadoProtagonista = data.Protagonista.ToList();

            }
            return listadoProtagonista;
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

        /// Registrar Protagonista
        //////////////////////////////////////////////////////

        static public bool RegistrarProtagonista(Protagonista Protagonista)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Protagonista.Add(Protagonista);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Protagonista
        //////////////////////////////////////////////////////
        static public bool ActualizarProtagonista(Protagonista Protagonista) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Protagonista actual = data.Protagonista.Where(x => x.CodInterprete == Protagonista.CodInterprete).FirstOrDefault();// alias
                    actual.CodPelicula = Protagonista.CodPelicula;
                    actual.NombreProtagonista = Protagonista.NombreProtagonista;
                    actual.EsPrincipal = Protagonista.EsPrincipal;
                  
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar Interprete
        //////////////////////////////////////////////////////
        static public bool EliminarProtagonista(int CodInterprete) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Protagonista Protagonista = data.Protagonista.Where(x => x.CodInterprete == CodInterprete).FirstOrDefault();// alias

                    data.Protagonista.Remove(Protagonista);
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
