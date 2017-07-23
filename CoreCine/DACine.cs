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

        /// Registrar Cine
        //////////////////////////////////////////////////////

        static public bool RegistrarCine(Cine cine)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities1())
                {
                    data.Cine.Add(cine);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Cine
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

        /// Eliminar Cine
        //////////////////////////////////////////////////////
        static public bool EliminarCine(int Codcine) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities1())
                {
                    Cine cine = data.Cine.Where(x => x.CodCine == Codcine).FirstOrDefault();// alias

                    data.Cine.Remove(cine);
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
