using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAAsiento
    {

        static public List<Asiento> ListadoAsiento()
        {
            List<Asiento> listadoAsiento = new List<Asiento>();
            using (var data = new CineDATABASEEntities())
            {

                listadoAsiento = data.Asiento.ToList();

            }
            return listadoAsiento;
        }

        static public List<Sala> ListadoSala()
        {
            List<Sala> listadoSala = new List<Sala>();
            using (var data = new CineDATABASEEntities())
            {

                listadoSala = data.Sala.ToList();

            }
            return listadoSala;
        }

        /// Registrar Asiento
        //////////////////////////////////////////////////////

        static public bool RegistrarAsiento(Asiento Asiento)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Asiento.Add(Asiento);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Asiento
        //////////////////////////////////////////////////////
        static public bool ActualizarAsiento(Asiento Asiento) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Asiento actual = data.Asiento.Where(x => x.CodAsiento == Asiento.CodAsiento).FirstOrDefault();// alias
                    actual.DescripcionAsiento = Asiento.DescripcionAsiento;
                    actual.CodSala = Asiento.CodSala;
                    actual.TipoAsiento = Asiento.TipoAsiento;
                    actual.Disponible = Asiento.Disponible;
                    
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
        static public bool EliminarAsiento(int CodAsiento) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Asiento Asiento = data.Asiento.Where(x => x.CodAsiento == CodAsiento).FirstOrDefault();// alias

                    data.Asiento.Remove(Asiento);
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
