using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCine
{
    public class DASala
    {

        static public List<Sala> ListadoSala()
        {
            List<Sala> listadoSala = new List<Sala>();
            using (var data = new CineDATABASEEntities())
            {

                listadoSala = data.Sala.ToList();

            }
            return listadoSala;
        }

        static public List<Cine> ListadoCine()
        {
            List<Cine> listadoCine = new List<Cine>();
            using (var data = new CineDATABASEEntities())
            {

                listadoCine = data.Cine.ToList();

            }

            return listadoCine;
        }
        /// Registrar sala
        //////////////////////////////////////////////////////

        static public bool RegistrarSala(Sala Sala)
        {
            bool exito = true;

            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    data.Sala.Add(Sala);
                    data.SaveChanges();
                }
            }
            catch
            {
                exito = false;
            }

            return exito;
        }

        /// Actualizar Sala
        //////////////////////////////////////////////////////
        static public bool ActualizarSala(Sala Sala) // referido a objeto
        {
            bool exito = true;
            try
            {
                using (var data = new CineDATABASEEntities())
                {
                    // realizar la consulta y actualizar
                    Sala actual = data.Sala.Where(x => x.CodSala == Sala.CodSala).FirstOrDefault();// alias
                    actual.NombreSala = Sala.NombreSala;
                    actual.Capacidad = Sala.Capacidad;
                    actual.Tipo = Sala.Tipo;
                    actual.CodCine = Sala.CodCine;

                    data.SaveChanges();
                }
            }
            catch (Exception)
            {
                exito = false;
            }
            return exito;

        }

        /// Eliminar Sala
        //////////////////////////////////////////////////////
        static public bool EliminarSala(int CodSala) // referido a borrar
        {
            bool exito = true;
            try
            {

                using (var data = new CineDATABASEEntities())
                {
                    Sala Sala = data.Sala.Where(x => x.CodSala == CodSala).FirstOrDefault();// alias

                    data.Sala.Remove(Sala);
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
