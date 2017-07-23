using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DACine
    {
        /// Listado de Cine
        //////////////////////////////////////////////////////
        static public List<Cine> ListadoCine()
        {
            List<Cine> listadoCine = new List<Cine>();
            using (var data = new CineDATABASEEntities1())
            {

                listadoCine = data.Cine.ToList();

            }

            return listadoCine;
        }

        /// Actualizar de Cine
        //////////////////////////////////////////////////////
        static public bool ActualizarCine(Cine cine) // referido a objeto
        {
            bool exito = true;           
            try
            {
                using (var data = new CineDATABASEEntities1())
                {
                    // realizar la consulta y actualizar
                    Cine actual = data.Cine.Where(x => x.CodCine == cine.CodCine).FirstOrDefault();// alias
                    actual.NombreCine = cine.NombreCine;
                    actual.Direccion = cine.Direccion;                   
                    data.SaveChanges();
                }
            }
            catch (Exception)
            {                
                exito = false;
            }
            return exito;

        }

        /// Crear Cine
        //////////////////////////////////////////////////////

        /// Eliminar Cine
        //////////////////////////////////////////////////////




    }
}
