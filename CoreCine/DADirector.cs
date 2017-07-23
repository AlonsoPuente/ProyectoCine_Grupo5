using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DADirector
    {

        static public List<Director> ListadoDirector()
        {
            List<Director> listadoDirector = new List<Director>();
            using (var data = new CineDATABASEEntities())
            {

                listadoDirector = data.Director.ToList();

            }
            return listadoDirector;
        }

        /// Registrar Pedido
        //////////////////////////////////////////////////////

        static public bool RegistrarDirector(Director Director)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Director.Add(Director);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Pedido
        //////////////////////////////////////////////////////
        static public bool ActualizarDirector(Director Director) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Director actual = data.Director.Where(x => x.CodDirector == Director.CodDirector).FirstOrDefault();// alias
                    actual.NombreDirector = Director.NombreDirector;

                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar Pedido
        //////////////////////////////////////////////////////
        static public bool EliminarDirector(int CodDirector) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Director Director = data.Director.Where(x => x.CodDirector == CodDirector).FirstOrDefault();// alias

                    data.Director.Remove(Director);
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
