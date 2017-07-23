using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DAInterprete
    {
        static public List<Interprete> ListadoInterprete()
        {
            List<Interprete> listado = new List<Interprete>();

            using (var data = new CineDATABASEEntities1())

            {
                listado = data.Interprete.ToList();
            }

            return listado;
        }
        static public bool RegistrarInterprete(Interprete interprete)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities1())
                {
                    data.Interprete.Add(interprete);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }
        static public bool EliminarInterprete(int Codinterprete ) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities1())
                {
                    Interprete interprete = data.Interprete.Where(x => x.CodInterprete == Codinterprete).FirstOrDefault();// alias

                    data.Interprete.Remove(interprete);
                    data.SaveChanges();

                }
            }
            catch (Exception)
            {

                exito = false;
            }

            return exito;
        }
        static public bool ActualizarInterprete(Interprete interprete)
        {
            bool exito = true; 
            try
            {
                using (var data = new CineDATABASEEntities1())
                {

                    Interprete actual = data.Interprete.Where(x => x.CodInterprete == interprete.CodInterprete).FirstOrDefault();

                    actual.CodInterprete = interprete.CodInterprete;
                    actual.Paterno = interprete.Paterno;
                    actual.Materno = interprete.Materno;
                    actual.Nombres = interprete.Nombres;
                    actual.Nacionalidad = interprete.Nacionalidad;
                    actual.Foto = interprete.Foto;
                    actual.Bio = interprete.Bio;


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
